# OpenConnectSDK项目

-----------------

QQConnect and WeiboConnect SDK

-----------------

[![NuGet](http://img.shields.io/nuget/v/OpenConnectSDK.svg?style=flat)](https://www.nuget.org/packages/OpenConnectSDK/)
[![Downloads](https://img.shields.io/nuget/dt/OpenConnectSDK.svg)](https://www.nuget.org/packages/OpenConnectSDK/)

-----------------

项目起源：工作中需要将网站接入QQ登录、微博登录和微信登录。但是QQ开放平台SDK的C#开源项目2012年已经停止维护，微博SDK的C#开源项目也处于瘫痪状态。所以发起了这个项目，希望能够长期维护一个QQ和微博接入的SDK。

-----------------

项目目标：本项目基于以下几个现状

1. QQ开放平台SDK（主要基于QQ空间的功能）和微博SDK的大部分API实际上无人使用，也无力同步官方的Api更新进行维护。
2. QQ登录和微博登录的实际需求依然存在，需要维护一个QQ开放平台SDK和微博SDK的精简核心Api类库。

-----------------
项目现状：已有以下用于QQ和微博开放平台接入的核心Api

1. QQ和微博开放平台的OAuth2登录
	OpenConnectSDK.QQ.Api.QQOAuthApi类和OpenConnectSDK.Weibo.Api.WeiboOAuthApi类
2. 微博和QQ开放平台基本用户信息获取
	OpenConnectSDK.QQ.Api.QQUserApi类和OpenConnectSDK.Weibo.Api.WeiboUserApi类

-----------------
项目发展：

1. 维持最低限度的与官方Api的同步维护和Bug修正。
2. 适时添加测试用例。
3. 如果类库有了一定的用户量，适时添加Sample项目。
4. 如果您愿意提交PR，将自己用到的QQ和微博核心SDK合并进来，请保证能够在一段时间内去维护这部分核心Api，保证可用性。
5. 如果您愿意提交PR，将人人网、开心网、豆瓣等开放平台SDK整合进来，请保证能够在一段时间内去维护这部分核心Api，保证可用性。
6. 长时间无人维护和使用的Api，如果我也没有时间维护，会逐步废弃并取消，宁缺勿滥。

-----------------

本库为.NET4.5，其他.NET版本请Fork建立分支并自行维护。

-----------------

本库不维护微信开放平台相关Api，推荐使用WeiXinMPSDK项目，地址 https://github.com/JeffreySu/WeiXinMPSDK ，该库功能完整，维护比较活跃，本库作者也有少量参与。