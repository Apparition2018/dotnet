## [改进表单和验证在 Blazor Web 应用中的工作方式](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/)
### 使用 Blazor 事件处理程序将 C# 代码附加到 DOM 事件
- 使用 Blazor 和 C# 处理事件
    - Blazor 指令与等效的 HTML 事件具有相同的名称
    - 事件处理程序方法提供上下文信息参数，如 MouseEventArgs、KeyboardEventArgs
- [JavaScript 事件处理 vs Blazor 事件处理](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/2-attach-csharp-code-dom-events-blazor-event-handlers#understand-event-handling-in-javascript-versus-event-handling-with-blazor)
- [以异步方式处理事件](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/2-attach-csharp-code-dom-events-blazor-event-handlers#handle-events-asynchronously)：`async`、`await`
- 使用事件聚焦到 DOM 元素
    ```razor
    <button class="btn btn-primary" @onclick="ChangeFocus">Click me to change focus</button>
    <input @ref=InputField @onfocus="HandleFocus" value="@data"/>

    @code {
        private ElementReference InputField;
        private string data;

        private async Task ChangeFocus()
        {
            await InputField.FocusAsync();
        }

        private async Task HandleFocus()
        {
            data = "Received focus";
        }
    }
    ```
- 内联事件处理程序：Lambda
- [覆盖事件的默认 DOM 操作](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/2-attach-csharp-code-dom-events-blazor-event-handlers#override-default-dom-actions-for-events)
    - preventDefault
    - stopPropagation
- [使用 EventCallback 处理跨组件的事件](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/2-attach-csharp-code-dom-events-blazor-event-handlers#use-an-eventcallback-to-handle-events-across-components)
### 练习 - 为 onclick 事件创建 Blazor 事件处理程序
- 克隆项目 `git clone https://github.com/MicrosoftDocs/mslearn-use-forms-in-blazor-web-apps.git BlazingPizza`
- 重构结账页面
    - @see [Checkout.razor](Pages/Checkout.razor)：`<div class="main">` 呈现为两列（① `<div class="checkout-cols">` ②`</button>`）
    - @see [OrderReview.razor](Shared/OrderReview.razor)
    - @see [AddressEditor.razor](Shared/AddressEditor.razor)
- 提高表单的可用性：提交订单后聚焦到 Name input 上，@see [AddressEditor.razor](Shared/AddressEditor.razor)
    ```razor
            <input @ref="startName" @bind="Address.Name"/>
    ……
    @code {
        ……
        private ElementReference startName;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender) {
                await startName.FocusAsync();
            }
        }
    }
    ```
### [利用 Blazor 表单的强大功能](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/4-take-advantage-power-blazor-forms)
- EditForm
    - [数据绑定](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/4-take-advantage-power-blazor-forms#create-an-editform-with-data-binding)：可将对象与 EditForm 关联
    - [表单提交](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/4-take-advantage-power-blazor-forms#handle-form-submission)：遵循 Blazor 事件模型
        - EditContext：跟踪作为模型的当前对象的状态
    - [输入元素](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/4-take-advantage-power-blazor-forms#understand-blazor-input-controls)：提供了具有其他功能（例如内置验证和数据绑定）的输入组件库
### 练习 - 使用 Blazor 组件创建地址表单
- 添加 Blazor EditForm 组件
    - @see [Checkout.razor](Pages/Checkout.razor)：删除 `</button>` @onclick 事件；从 `PlaceOrder()` 方法中删除 `isSubmitting = true`
        ```razor
            <EditForm Model=Order.DeliveryAddress OnSubmit=CheckSubmission>
        ……
        @code {
            private async Task CheckSubmission()
            {
                isSubmitting = true;
                await PlaceOrder();
                isSubmitting = false;
            }
        }
        ```
- 将 HTML 元素替换为 Blazor 组件，@see [AddressEditor.razor](Shared/AddressEditor.razor)
    - `<input` 替换为 `<InputText`
    - `@bind=` 替换为 `@bind-Value=`
    - 仅 HTML 元素支持 FocusAsync：删除 `@ref="startName"`、startName、OnAfterRenderAsync()
- 提交表单前检查是否存在空字段，@see [Checkout.razor](Pages/Checkout.razor)
    ```razor
                    @if (isError)
                    {
                        <div class="alert alert-danger">Please enter a name and address.</div>
                    }
    ……
    @code {
        ……
        bool isError = false;

        private async Task CheckSubmission(EditContext editContext)
        {
            isSubmitting = true;
            var model = editContext.Model as Address;
            isError = string.IsNullOrWhiteSpace(model?.Name)
                      || string.IsNullOrWhiteSpace(model?.Line1)
                      || string.IsNullOrWhiteSpace(model?.PostalCode);
            if (!isError)
            {
                await PlaceOrder();
            }
            isSubmitting = false;
        }
    }
    ```
### [隐式验证用户输入，而无需编写验证代码](https://learn.microsoft.com/zh-cn/training/modules/blazor-improve-how-forms-work/6-validate-user-input-implicitly)
- 多种验证选项
    - 使用注释属性，告诉 Blazor 何时需要值，以及它们应采用什么格式
        - `[required]`、`[Range]`、`[EmailAddress]`、`[ValidationNever]`、`[CreditCard]`、`[Compare]`、`[Phone]`、`[RegularExpression]`、`[StringLength]`、`[Url]`
        - 自定义验证失败消息：`[Required(ErrorMessage = "...")]`
        - 自定义验证属性：继承 `ValidationAttribute`
    - DataAnnotationsValidator 组件：根据用户输入的值检查模型注释
    - ValidationSummary 组件：在提交的表单中显示所有验证消息的摘要
    - ValidationMessage 组件：在每个控件旁边显示验证消息
- 在表单提交时，在服务器端处理表单验证
    - OnSubmit
    - OnValidSubmit 和 OnInvalidSubmit
### 练习 - 将服务器端和客户端数据验证添加到地址表单
- 向 Blazor 模型添加数据注释
    - @See [Address.cs](Model/Address.cs)
    - @see [Checkout.razor](Pages/Checkout.razor)：删除 `CheckSubmission()`
        ```razor
            <EditForm Model=Order.DeliveryAddress OnValidSubmit=PlaceOrder>
        ……
                <ValidationSummary/>
                <DataAnnotationsValidator/>
        ```
- 改进 EditFrom 错误消息
    - @see [Checkout.razor](Pages/Checkout.razor)：删除 `<ValidationSummary/>`
    - @see [AddressEditor.razor](Shared/AddressEditor.razor) 每个 `<ValidationMessage>`
    - 自定义错误消息：@See [Address.cs](Model/Address.cs) ErrorMessage
- 还原整个错误信息并禁用“提交”按钮
    - @see [Checkout.razor](Pages/Checkout.razor)：`OnInvalidSubmit=ShowError`、`ShowError()`
        ```razor
            …… OnInvalidSubmit=ShowError>
        ……
        @code {
            ……
            async Task PlaceOrder()
            {
                isError = false;
                isSubmitting = true;
                var response = await HttpClient.PostAsJsonAsync($"{NavigationManager.BaseUri}orders", OrderState.Order);
                var newOrderId= await response.Content.ReadFromJsonAsync<int>();
                OrderState.ResetOrder();
                NavigationManager.NavigateTo($"myorders/{newOrderId}");
            }

            protected void ShowError()
            {
                isError = true;
            }
        }
        ```
- 当所有字段都正确时，启用“提交”按钮
    - @see [Checkout.razor](Pages/Checkout.razor)：更改 EditForm 以使用 EditContext（而不是模型；删除 isSubmitting；在 `PlaceOrder()` 删除 `isError = false;`
        ```razor
        @implements IDisposable
        ……
            <EditForm EditContext=editContext OnValidSubmit=PlaceOrder>
        ……
                <button class="checkout-button btn btn-warning" type="Submit" disabled=@isError>
        @code {
            ……
            private EditContext editContext;

            protected override void OnInitialized()
            {
                editContext = new(Order.DeliveryAddress);
                editContext.OnFieldChanged += HandleFieldChanged;
            }

            private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
            {
                isError = !editContext.Validate();
                StateHasChanged();
            }

            public void Dispose()
            {
                editContext.OnFieldChanged -= HandleFieldChanged;
            }
        }
        ```
### Reference
- [Blazor 事件处理](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/components/event-handling)
- [Blazor 表单概述](https://learn.microsoft.com/zh-cn/aspnet/core/blazor/forms/)
---
