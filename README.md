# seele-test

黑马考试使用

## Todo list:

* [√] ~~.Net 项目搭建~~
* [√] ~~Controller 搭建~~
* [√] ~~Service 搭建~~
* [√] ~~Repository 搭建~~
* [√] ~~Http Client 搭建~~
* [√] ~~数据库导入~~
* [√] ~~下游服务导入（Fake）~~
* [√] ~~Docker Compose 集成~~
* [　] Redis Client 搭建
* [　] 集成测试
* [　] Exception Filter
* [　] 完成一个卡

## 服务简介

1. ConsighmentService

    1. 拍卖委托服务的 api 应用
    1. 技术栈：.Net 6, C# 10，EF Core
    1. 启动命令
        ```
        dotnet run
        ```
    1. 依赖
        1. 下游支付服务的 api 应用
        1. PostgeSql

1. MockeServer
    1. 支付服务的 api 应用
    1. 技术栈：Node.js, Express.js, npm
    1. 启动命令
        ```
        npm strat
        ```
1. UnitTest
    1. 拍卖委托服务的单元测试
    1. 包含 Controller、Service、Repository、Http Client 的单元测试
    1. 技术栈：.Net 6, C# 10，EF Core, xUnit
    1. 测试命令
        ```
        dotnet test
        ```
1. ApiTest
    1. 拍卖委托服务的集成测试
    1. Fake Database 和下游服务的集成测试
    1. 技术栈：.Net 6, C# 10，EF Core, xUnit, TestHost
    1. 测试命令
        ```
        dotnet test
        ```

## 集合启动
1. 使用 docker compose 启动
1. 使用 adminer 新建数据库
1. 使用 EF tool 根据代码生成数据库表
