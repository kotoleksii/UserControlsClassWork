<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SmartUploader.ascx.cs" Inherits="UserControls.SmartUploader" %>

<asp:Panel ID="component" runat="server">

    <div>
        <asp:FileUpload ID="fileUpload" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click"/>
    </div>

    <div>
        <asp:Label ID="lblUploadResult" runat="server" Text=""></asp:Label>
    </div>
</asp:Panel>

<script>

    const fileUploader = document.querySelector("#SmartUploader_fileUpload");
    const uploaderPanel = document.querySelector("#SmartUploader_componentPanel");

    fileUploader.accept = '<%=FileFilterAttribute %>';

    <% if(!string.IsNullOrEmpty(CssClass)) 
    {
    %>
        uploaderPanel.className = '';
        uploaderPanel.classList.add('<%=CssClass %>');
    <% } %>
    <% else
    {
    %>

    <style></style>

    <%
    }
    %>
</script>
