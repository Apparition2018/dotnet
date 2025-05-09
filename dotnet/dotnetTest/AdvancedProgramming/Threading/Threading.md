# 线程处理

---
## [托管线程处理基础知识](https://learn.microsoft.com/zh-cn/dotnet/standard/threading/threads-and-threading)
### 线程与线程处理
- 从 .NET Framework 4 开始，使用多线程的推荐方法是使用
    [任务并行库 (TPL)](../ParallelProgramming/TaskParallelLibrary/TaskParallelLibrary.md)
    和
    [并行 LINQ (PLINQ)](../../Guide/LINQ/LINQ.md#并行-linq--plinq-)
- TPL 和 PLINQ 依赖于 ThreadPool 线程
### [为多线程处理同步数据](ManagedThreadingBasics/SynchronizeDataForMultithreading.cs)
### 前台线程和后台线程
- 唯一不同：后台线程不会确保托管执行环境一直运行。一旦托管进程（其中 .exe 文件为托管程序集）中的所有前台线程都停止，系统会停止并关闭所有后台线程
- 确认是后台线程还是前台线程(Thread.IsBackground)
- 属于托管线程池(Thread.IsThreadPoolThread)的线程是后台线程
- 从非托管代码进入托管执行环境的所有线程都会标记为后台线程
- 默认情况下，通过新建并启动 Thread 对象生成的所有线程都是前台线程
### [Windows 中的托管和非托管线程处理](https://learn.microsoft.com/zh-cn/dotnet/standard/threading/managed-and-unmanaged-threading-in-windows)
- 运行时以外创建的线程可以通过 COM 互操作、COM DllGetClassObject 函数和平台调用进入托管执行环境
    - 运行时将托管对象作为 COM 对象向非托管领域公开
### 线程本地存储区 (Thread Local Storage)
- 线程相对静态字段：在编译时可以预测确切需求时使用；性能最佳；支持编译时类型检查
- 数据槽：只能在运行时发现实际需求时使用；数据存储为 Object，使用前必须强制转换为正确类型
---
## [使用线程和线程处理](UsingThreadsAndThreading.cs)

---
## [最佳实践](ManagedThreadingBestPractices.cs)
- [一般性建议](https://learn.microsoft.com/zh-cn/dotnet/standard/threading/managed-threading-best-practices#general-recommendations)

|   操作   |                      建议                      |             不建议              |
|:------:|:--------------------------------------------:|:----------------------------:|
| 终止其他线程 |                                              |         Thread.Abort         |
| 同步多个线程 | Mutex、ManualRestEvent、AutoResetEvent、Monitor | Thread.Suspend、Thread.Resume |
| 简单状态更改 |                 Interlocked                  |             lock             |
---
## [线程处理对象和功能](ThreadingObjectsAndFeatures)
### [ThreadPool](../../API/System/Threading/ThreadPoolTests.cs)
### [Timer](ThreadingObjectsAndFeatures/Timers.cs)

|       | System.Threading.Timer |    System.Timers.Timer    | System.Threading.PeriodicTimer |
|:-----:|:----------------------:|:-------------------------:|:------------------------------:|
| 实现方式  |       轻量级、线程池回调        | 事件驱动（封装 Threading.Timer）  |             异步顺序执行             |
| 线程安全  |         手动同步回调         |  手动同步事件 或 AutoRest=false  |            单线程、无需同步            |
| 异步支持  |        需封装异步到回调        |         需封装异步到事件          |         支持 async/await         |
| UI 交互 |         Invoke         |    SynchronizingObject    |       Dispatcher.Invoke        |
| 触发方式  |          回调函数          |          Elapsed          |      WaitForNextTickAsync      |
| 如何启动  |          默认启动          |  Enabled=true 或 Start()   |      WaitForNextTickAsync      |
| 资源管理  |       Dispose()        | Enabled=false 或 Dispose() |   CancellationToken 或 using    |
| 重复触发  |    通过 Change() 动态调整    |   AutoReset 属性控制是否自动重复    | 循环调用 WaitForNextTickAsync 实现重复 |
| 使用场景  |         轻量级任务          |      复杂事件逻辑 或 UI 交互       |            异步高并发轮询             |
### [同步基元](ThreadingObjectsAndFeatures/SynchronizationPrimitives.cs)
- 同步对共享资源的访问

|      |    Monitor    |   SpinLock    | ReaderWriterLockSlim |  SemaphoreSlim  | Semaphore |   Mutex   | AutoResetEvent |
|:----:|:-------------:|:-------------:|:--------------------:|:---------------:|:---------:|:---------:|:--------------:|
| 实现层级 |  基于对象头同步块索引   |     自旋等待      |      基于轻量级队列管理       |     轻量级信号量      | 依赖操作系统信号量 | 依赖操作系统互斥体 |    依赖内核事件对象    |
| Mode |      用户态      |      用户态      |         用户态          |       用户态       |    内核态    |    内核态    |      内核态       |
| 跨进程  |      不支持      |      不支持      |         不支持          |       不支持       | 支持（命名信号量） | 支持（命名互斥体） |    支持（命名事件）    |
| 锁类型  |      独占锁      |      独占锁      |        读写分离锁         |    轻量级计数信号量     |   计数信号量   |    独占锁    |   事件信号（单唤醒）    |
| 锁升级  | 偏向锁→轻量级锁→重量级锁 |       /       |    支持可升级读锁（读锁→写锁）    |        /        |     /     |     /     |       /        |
|  异步  |      不支持      |      不支持      |         不支持          | 支持（WaitAsync()） |    不支持    |    不支持    |      不支持       |
| 阻塞方式 |  用户态自旋→内核态休眠  |  用户态自旋（忙等待）   |    写锁用户态队列 + 自旋等待    | 用户态自旋 + 用户态异步队列 |   内核态休眠   |   内核态休眠   |     内核态休眠      |
| 性能开销 |   低（用户态优先）    |  极低（无上下文切换）   |      次高（读写队列管理）      | 中（用户态计数器+异步队列）  |  高（涉及内核）  |  高（涉及内核）  |    高（涉及内核）     |
| 轻量级  |  中（需维护同步块索引）  | 最轻（无内存分配，仅自旋） |      中（需维护读写队列）      | 次轻（用户态计数器+异步队列） |  重（依赖内核）  |  重（依赖内核）  |    重（依赖内核）     |
| 适用场景 |     高频短锁      |     极短临界区     |      读多写少的高并发读取      |     进程内异步限流     |  跨进程资源池   |  跨进程独占资源  |     单次线程唤醒     |
### 线程安全集合

---
