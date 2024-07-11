## [使用 Blazor 构建四子棋游戏](https://learn.microsoft.com/zh-cn/training/modules/dotnet-connect-four/)
### [Blazor](https://learn.microsoft.com/zh-cn/training/modules/dotnet-connect-four/2-blazor)
- [WebAssembly](https://learn.microsoft.com/zh-cn/training/modules/dotnet-connect-four/2-blazor#what-is-webassembly)
- 设置 Blazor 组件的样式
    1. 普通 CSS 样式
    2. CSS 隔离：创建与组件同名的文件并添加 .css 文件扩展名
    3. HeadContent 标记：定义要添加到页面 HTML 标头的内容
        ```razor
        <HeadContent>
            <style>
                ...my styles here
            </style>
        </HeadContent>
        ```
### [练习 - Blazor](https://learn.microsoft.com/zh-cn/training/modules/dotnet-connect-four/3-exercise-blazor)
- 创建新的 Blazor 项目 (Visual Studio 2022)
    1. 文件 → 新建 → 项目
    2. 模板选择 Blazor Web App → 下一步
    3. 项目名称：ConnectFour → 下一步
        ```
        框架                         .NET 8.0
        身份验证类型                  无
        Interactive render mode     Server
        Interactivity location      Per page/component
        ```
- 创建棋盘组件
    - 创建 [Board.razor](Components/Board.razor)
    - 将 Board 组件添加到 Home 页面：@see [Home.razor](Components/Pages/Home.razor) `<Board/>`
- 向游戏棋盘添加内容和样式
    - @see [Board.razor](Components/Board.razor)
        ```razor
        <HeadContent>
            <style>
                :root {
                    --board-bg: yellow;  /** the color of the board **/
                    --player1: red;      /** Player 1's piece color **/
                    --player2: blue;     /** Player 2's piece color **/
                }
            </style>
        </HeadContent>

        <div>
           <div class="board">
              @for (var i = 0; i < 42; i++)
              {
                 <span class="container">
                    <span></span>
                 </span>
              }
           </div>
        </div>
        ```
    - @see [Board.razor.css](Components/Board.razor.css)
### [练习 - 游戏逻辑](https://learn.microsoft.com/zh-cn/training/modules/dotnet-connect-four/5-exercise-game-logic)
- 添加游戏状态
    - @see [GameState.cs](GameState.cs)
    - @see [Program.cs](Program.cs)：`builder.Services.AddSingleton<GameState>();`
    - @see [Board.razor](Components/Board.razor)：`@inject GameState State`
- 重置状态：@see [Board.razor](Components/Board.razor)
    ```razor
    @code {
        protected override void OnInitialized()
        {
            State.ResetBoard();
        }
    }
    ```
- 创建游戏棋子：@see [Board.razor](Components/Board.razor)
    ```razor
        @for (var i = 0; i < 42; i++)
        {
            <span class="@pieces[i]"></span>
        }
    ……
    @code {
        private string[] pieces = new string[42];
    }
    ```
- 处理游戏棋子的放置：@see [Board.razor](Components/Board.razor) `PlayPiece()`
- 选择列
    - @see [Board.razor](Components/Board.razor)
        ```razor
        <nav>
            @for (byte i = 0; i < 7; i++)
            {
                var col = i;
                <span title="Click to play a piece" @onclick="() => PlayPiece(col)">🔽</span>
            }
        </nav>
        ```
    - @see [Home.razor](Components/Pages/Home.razor) `<Board @rendermode="InteractiveServer"/>`
- 获胜和错误处理：@see [Board.razor](Components/Board.razor)
    ```razor
    <article>
        @winnerMessage <button style="@ResetStyle" @onclick="ResetGame">Reset the game</button>
        <br/>
        <span class="alert-danger">@errorMessage</span>
        <span class="alert-info">@CurrentTurn</span>
    </article>
    ……
    @code {
        ……
        private string winnerMessage = string.Empty;
        private string errorMessage = string.Empty;

        private string CurrentTurn => (winnerMessage == string.Empty) ? $"Player {State.PlayerTurn}'s Turn" : "";
        private string ResetStyle => (winnerMessage == string.Empty) ? "display: none;" : "";
        ……
        private void PlayPiece(byte col)
        {
            errorMessage = string.Empty;
            try
            {
                var player = State.PlayerTurn;
                var turn = State.CurrentTurn;
                var landingRow = State.PlayPiece(col);
                pieces[turn] = $"player{player} col{col} drop{landingRow}";
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
            }
            winnerMessage = State.CheckForWin() switch
            {
                GameState.WinState.Player1_Wins => "Player 1 Wins!",
                GameState.WinState.Player2_Wins => "Player 2 Wins!",
                GameState.WinState.Tie => "It's a tie!",
                _ => ""
            };
        }

        void ResetGame()
        {
            State.ResetBoard();
            winnerMessage = string.Empty;
            errorMessage = string.Empty;
            pieces = new string[42];
        }
    }
    ```
### [练习 - 使用参数进行自定义](https://learn.microsoft.com/zh-cn/training/modules/dotnet-connect-four/6-exercise-parameters)
- 使用参数自定义棋盘
    - @see [Board.razor](Components/Board.razor)
        ```razor
        @using System.Drawing

        <HeadContent>
            <style>
                :root {
                    --board-bg: @ColorTranslator.ToHtml(BoardColor);
                    --player1: @ColorTranslator.ToHtml(Player1Color);
                    --player2: @ColorTranslator.ToHtml(Player2Color);
                }
            </style>
        </HeadContent>
        ……
        @code {
            ……
            [Parameter]
            public Color BoardColor { get; set; } = ColorTranslator.FromHtml("yellow");
            [Parameter]
            public Color Player1Color { get; set; } = ColorTranslator.FromHtml("red");
            [Parameter]
            public Color Player2Color { get; set; } = ColorTranslator.FromHtml("blue");
        }
        ```
    - @see [Home.razor](Components/Pages/Home.razor)
        ```razor
        <Board @rendermode="InteractiveServer"
               BoardColor="System.Drawing.Color.Black"
               Player1Color="System.Drawing.Color.Green"
               Player2Color="System.Drawing.Color.Purple"/>
        ```
---
