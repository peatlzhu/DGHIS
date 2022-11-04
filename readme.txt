项目原始代码从 https://github.com/jhrscom/JHRS.git 获取.

更新项目:
1.Prism 7.2=> 8
2.升级HandyControl 2.8=->3.3
3.移除Prism.Logging.
4.移除MaterialDesign,防止与HandyControl 样式冲突.
5. Interaction.Triggers =>  xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
6.升级nuget 引用包,newston.json....
7.ServiceLocator.Current.TryResolve => ContainerLocator.Container.Resolve    (Prism 7.2=> 8 ioc 方法修改)