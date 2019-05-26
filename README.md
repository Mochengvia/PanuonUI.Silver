<a href="https://996.icu" target='_blank'><img src="https://img.shields.io/badge/link-996.icu-red.svg"></a>

# Panuon.UI.Silver
Panuon.UI optimized version. A beautiful wpf ui library using templates &amp; attached properties.

This is a developing program.

# Donate
Panuon.UI.Silver is an open source library.Your support will motivate me to continue Panuon.UI.Silver development.  

Zhifubao (Huabei supports):

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Global/zhifubao.jpg)

Paypal:  
paypal.me/Zeoun  


# Overview
Blue theme (colors can be changed):

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Panuon.UI.Silver/overview.jpg)

Pink theme :

![](https://raw.githubusercontent.com/Ruris/Panuon.Documents/master/Resources/Panuon.UI.Silver/overview_2.jpg)


### Work with helper :
Button / CheckBox / RadioButton / TextBox / PasswordBox / ComboBox / Expander / GroupBox / Expander

### Dependent controls:
Calendar / Carousel / Loading / MultiSelector

### Styles only :
DataGrid / ScrollViewer (MiniScrollViewer)

# Quick Start

1. Add "Panuon.UI.Silver.dll" to your project references.

2. Append resource dictionary below to &lt;MergedDictionaries&gt; node in "App.xaml" , &lt;Window.Resources&gt; , or other resource nodes.
```
<ResourceDictionary Source="pack://application:,,,/Panuon.UI.Silver;component/Control.xaml" />
```              

3. Add reference in c#/xaml code

```
(xaml)
xmlns:pu="clr-namespace:Panuon.UI.Silver;assembly=Panuon.UI.Silver"

(c#)
using Panuon.UI.Silver;
```

4. Try it:
```
(xaml)
<Button x:Name="BtnTest" pu:ButtonHelper.ButtonStyle="Outline" />

(c#)
ButtonHelper.SetButtonStyle(BtnTest, ButtonStyle.Outline);
```

5. PanuonUI.Silver integrated with FontAwesome.Use it in your programs:
```
(element property)
FontFamily="/Panuon.UI.Silver;component/Resources/#fontawesome"

(resource)
<FontFamily x:Key="IconFont">/Panuon.UI.Silver;component/Resources/#fontawesome</FontFamily>
...
FontFamily="{StaticResource IconFont}"
```
Copy icon from http://www.fontawesome.com.cn/cheatsheet

# Document
[Button](#Button)
[CheckBox](#CheckBox)
[RadioButton](#RadioButton)
[TextBox](#TextBox)
[PasswordBox](#PasswordBox)


## Button
ButtonHelper  
Namespace : Panuon.UI.Silver  
Example : 
```
<Button pu:ButtonHelper.ButtonStyle="Outline"
        pu:ButtonHelper.ClickStyle="Sink"
        Height="30"
        Width="120"/>  
```
Tips : For "Icon" property, You can set any control, fontawesome icon or image uri source to its value .Like this :
```
pu:ButtonHelper.Icon=""

pu:ButtonHelper.Icon="&#xf058;"

<pu:ButtonHelper.Icon>
    <Image Source="/Namespace;component/Resources/icon.jpg" Height="20" Width="20" />
</pu:ButtonHelper.Icon>

pu:ButtonHelper.Icon="/Namespace;component/Resources/icon.jpg"

```

Property Name | Property Type | Default Value | Description  
-|-|-|-
ButtonStyle | Enum(ButtonStyle) | Standard[/Outline/Hollow/Link] | gets or sets base button style .|
ClickStyle | Enum(ClickStyle) | None[/Sink] | gets or sets click effect of the button .|
Icon | Object | Null | gets or sets icon of the button, which placed before the content .| 
CornerRadius | CornerRadius | (0,0,0,0) | gets or sets border corner radius of the button .|
HoverBrush | Brush | #3E3E3E | gets or sets background("Standard" style ,background and borderbrush in "Hollow" Style, foreground and borderbrush in "Outline" style, foreground in "Link" style) of the button when mouse enter .|
ClickCoverBrush | Brush | #22FFFFFF | gets or sets cover mask of the button when mouse clicked .|
IsWaiting | Boolean | False | gets or sets whether the button is in waiting mode .Button will be disabled when IsWaiting="True".|
WaitingContent | Object | "Please wait..." | gets or sets content of the button when IsWaiting="True". |

## CheckBox
## RadioButton
## TextBox
## PasswordBox


