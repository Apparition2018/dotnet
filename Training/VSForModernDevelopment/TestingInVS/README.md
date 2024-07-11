## [Visual Studio 中的 C# 测试](https://learn.microsoft.com/zh-cn/training/modules/visual-studio-test-tools/)
### [三A](https://learn.microsoft.com/zh-cn/training/modules/visual-studio-test-tools/2-create-test#the-three-as)
    ```csharp
    [TestMethod]
    public void AddTest()
    {
        // Arrange 用于声明测试可能需要的任何变量
        var calculator = new Calculator();

        // Act 用于调用需要测试的代码
        var actual = calculator.Add(1, 1);

        // Assert 用于检查操作结果是否符合
        Assert.AreEqual(2, actual);
    }
    ```
### [练习 - 编写测试](https://learn.microsoft.com/zh-cn/training/modules/visual-studio-test-tools/2-create-test)
- 设置要测试的产品代码
    - 新建一个名为 [LearnMyCalculatorApp](LearnMyCalculatorApp) 的 .NET 控制台应用
    - @see [Calculator.cs](LearnMyCalculatorApp/Calculator.cs)
- 创建测试项目：新建一个名为 [LearnMyCalculatorApp.Tests](LearnMyCalculatorApp.Tests) 的 MSTest 单元测试项目
- 添加引用：`Select LearnMyCalculatorApp.Tests → Right-Click → Add → Reference… → LearnMyCalculatorApp`
### [强化测试技能](https://learn.microsoft.com/zh-cn/training/modules/visual-studio-test-tools/6-sharpen-test-skills)
- [Fluent 断言](https://fluentassertions.com/)：@see [CalculatorTests.cs](LearnMyCalculatorApp.Tests/CalculatorTests.cs) `AddTestFluentAssertion()`
- [数据驱动的测试](https://learn.microsoft.com/zh-cn/visualstudio/test/how-to-create-a-data-driven-unit-test)：使用不同的参数多次运行相同的测试方法，@see [CalculatorTests.cs](LearnMyCalculatorApp.Tests/CalculatorTests.cs) `AddDataTests()`
- 模拟
### Reference
- [将 Assert 类用于单元测试](https://learn.microsoft.com/zh-cn/visualstudio/test/using-the-assert-classes)
- [针对高级 Visual Studio 测试工具的文档](https://learn.microsoft.com/zh-cn/visualstudio/test/improve-code-quality)
- [使用命令行跨平台测试](https://learn.microsoft.com/zh-cn/dotnet/core/testing/unit-testing-with-mstest)
- [在 Azure DevOps 中运行测试](https://learn.microsoft.com/zh-cn/training/modules/run-functional-tests-azure-pipelines/)
- [测试资源管理器文档](https://learn.microsoft.com/zh-cn/visualstudio/test/run-unit-tests-with-test-explorer)
---
