# [成员 (Members)](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/members)

---
## [访问修饰符 (Access Modifiers)](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)
|                                      | public | protected internal | protected | internal | private protected | private |
|--------------------------------------|:------:|:------------------:|:---------:|:--------:|:-----------------:|:-------:|
| within the class                     |   √    |         √          |     √     |    √     |         √         |    √    |
| derived class same assembly          |   √    |         √          |     √     |    √     |         √         |    ×    |
| non-derived class same assembly      |   √    |         √          |     ×     |    √     |         ×         |    ×    |
| derived class different assembly     |   √    |         √          |     √     |    ×     |         ×         |    ×    |
| non-derived class different assembly |   √    |         ×          |     ×     |    ×     |         ×         |    ×    |
---
