<a href="https://996.icu" target='_blank'><img src="https://img.shields.io/badge/link-996.icu-red.svg"></a>

# Panuon.UI.Silver
Panuon.UI optimized version. A beautiful wpf ui library using templates &amp; attached properties.  
Panuon.UI的优化版本。一个漂亮的、使用样式与附加属性的WPF UI控件库。

This is a developing program.  
这是一个正在开发的项目。


# Examples 示例

![](https://github.com/Ruris/Panuon.Documents/blob/master/Resources/Panuon.UI.Silver/example_1.png?raw=true)

# Donate  捐赠
Panuon.UI.Silver is an open source library.Your support will motivate me to continue Panuon.UI.Silver development.    
Panuon.UI.Silver是一个完全开源的控件库。您的支持是项目得以发展的根本保证。

Zhifubao:  
支付宝：

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Global/zhifubao.jpg)

Paypal:  
paypal.me/Zeoun  

# Overview 概览

## Where is the document ? （文档在哪里？）
After downloading this repository, you can find document in our example program. Launch "Panuon.UI.Silver.Browser" project , and you will find it .  
文档位于示例程序中。当您下载该仓库后，只需启动"Panuon.UI.Silver.Browser"项目，即可看到文档。

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Panuon.UI.Silver/step1.png)

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Panuon.UI.Silver/step2.png)

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Panuon.UI.Silver/step3.png)

### Work with helper （需要使用Helper的控件）:
Button / CheckBox / RadioButton / TextBox / PasswordBox / ComboBox / Expander / GroupBox / Expander

### Dependent custom controls （独立自定义控件）:
Calendar / Carousel / Loading / MultiSelector

### Styles only （仅使用样式）:
DataGrid / ScrollViewer (MiniScrollViewer)

# Quick Start 开始使用

1. Add "Panuon.UI.Silver.dll" to your project references.  
将"Panuon.UI.Silver.dll"添加到你项目的引用中。

2. Append resource dictionary below to &lt;MergedDictionaries&gt; node in "App.xaml" , &lt;Window.Resources&gt; , or other resource nodes.  
将如下资源字典添加到App.xaml，&lt;Window.Resource&gt;或者其他资源节点下的&lt;MergedDictionaries&gt;中。
```
<ResourceDictionary Source="pack://application:,,,/Panuon.UI.Silver;component/Control.xaml" />
```              

3. Add reference in c#/xaml code  
在代码中添加引用。

```
(xaml)
xmlns:pu="clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.Silver"

(c#)
using Panuon.UI.Silver;
```

4. Try it:  
开始使用：
```
(xaml)
<Button x:Name="BtnTest" pu:ButtonHelper.ButtonStyle="Outline" />

(c#)
ButtonHelper.SetButtonStyle(BtnTest, ButtonStyle.Outline);
```

5. PanuonUI.Silver integrated with FontAwesome.Use it in your programs:  
PanuonUI.Silver内部集成了FontAwesome字体文件。你可以在你的项目中使用它：
```
(element property)
FontFamily="/Panuon.UI.Silver;component/Resources/#fontawesome"

(resource)
<FontFamily x:Key="IconFont">/Panuon.UI.Silver;component/Resources/#fontawesome</FontFamily>
...
FontFamily="{StaticResource IconFont}"
```
Copy icon from http://www.fontawesome.com.cn/cheatsheet  
从如上链接中拷贝图标。
