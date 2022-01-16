<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="UserControls.Upload" %>

<%@ Register Src="~/SmartUploader.ascx" TagPrefix="mc" TagName="SmartUploader" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        .cssUploader {
            background-color: aqua;
        }
        .cssUploader input[type=submit] {
            background-color: blueviolet;
        }
    </style>
    <form id="form1" runat="server">
        <div>
            <mc:SmartUploader 
                runat="server"
                id="SmartUploader"
                UploadFolder="MyFiles"
                AutoRename="True"
                AllowedFileTypes="Documents"
                OnFileUploaded="SmartUploader_FileUploaded"
                CssClass="cssUploader"
                />
            <asp:Label ID="uploadDetails" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
