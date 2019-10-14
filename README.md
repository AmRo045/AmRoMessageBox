# AmRoMessageBox 
Simple message box control for WPF.

[![NuGet Status](https://img.shields.io/nuget/v/AmRoMessageBox.svg?style=flat&label=AmRoMessageBox)](https://www.nuget.org/packages/AmRoMessageBox/)


## Installation Guide
Use the following command to install:
```
Install-Package AmRoMessageBox
```

#### Static Example
```C#
AmRoMessageBox.ShowDialog("Your Message ... ");
```
#### Non-Static Example
```C#
var messageBox = new AmRoMessageBox
{
    Background = "#333333",
    TextColor = "#ffffff",
    IconColor = "#3399ff",
    RippleEffectColor = "#000000",
    ClickEffectColor = "#1F2023",
    ShowMessageWithEffect = true,
    EffectArea = this,
    ParentWindow = this
};
messageBox.Show("Your Message ..."); 
```

## Properties
In the following table, you can see the AmRoMessageBox class properties:

| Property  | Type | Description | 
| ------------- | ------------- | ------------- |
| Background | string | Specifies the background color |
| TextColor | string | Specifies the text color |
| IconColor | string | Specifies the icon color |
| WindowEffectColor | string | Specifies the window effect color |
| EffectArea | object | Specifies display region of window effect |
| RippleEffectColor | string | Specifies the buttons Ripple effect color |
| ClickEffectColor | string | Specifies the buttons Click effect color |
| FontFamily | FontFamily | Specifies the MessageBox font |
| EffectOpacity | double | Specifies the transparency level of window effect |
| MessageFontSize | double | Specifies message content font size |
| CaptionFontSize | double | Specifies message caption font size |
| Direction | FlowDirection | Specifies the MessageBox direction |
| ButtonsText | AmRoMessageBoxButtonsText | Specifies the MessageBox buttons text |
| ParentWindow | Window | Specifies the owner window |
| ShowMessageWithEffect | bool | Specifies whether MessageBox has an window effect when displaying or not |

## Screenshots
![AmRoMessageBox Screenshot - Not Found](Docs/Screenshots/EN/AmRoMessageBoxDemo_EN_Screenshot1.png)
![AmRoMessageBox Screenshot - Not Found](Docs/Screenshots/EN/AmRoMessageBoxDemo_EN_Screenshot2.png)
![AmRoMessageBox Screenshot - Not Found](Docs/Screenshots/EN/AmRoMessageBoxDemo_EN_Screenshot3.png)
![AmRoMessageBox Screenshot - Not Found](Docs/Screenshots/EN/AmRoMessageBoxDemo_EN_Screenshot4.png)

## Persian References
<div>
    <ul dir="rtl">
        <li dir="rtl"><a href="https://sourcesara.com/messagebox-component-for-wpf/">آموزش نصب و استفاده از کامپوننت AmRoMessageBox</a></li>
        <li dir="rtl"><a href="https://sourcesara.com/wpf-tutorial-video-in-csharp-from-elementary-to-advanced/">فیلم آموزش WPF در سی شارپ</a></li>
        <li dir="rtl"><a href="https://sourcesara.com/">آموزش برنامه نویسی</a></li>
    </ul>
</div>
