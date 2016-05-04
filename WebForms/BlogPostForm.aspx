<%@ Page Title="Blog Post Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BlogPostForm.aspx.cs" Inherits="WebForms.BlogPostForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="txtTitle">
            Title
        </asp:Label>

        <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" Text="<%# Post.Title %>"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="txtPublishDate">
            Publish Date
        </asp:Label>

        <asp:TextBox runat="server" ID="txtPublishDate" TextMode="DateTime" CssClass="form-control" Text="<%# Post.PublishDate %>"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="txtBody">
            Body
        </asp:Label>

        <asp:TextBox runat="server" ID="txtBody" CssClass="form-control" TextMode="MultiLine" Rows="12" Columns="40" Text="<%# Post.Body %>"></asp:TextBox>
    </div>

    <p>
        <a href="Default.aspx" class="btn btn-default">Cancel</a>
        <asp:Button runat="server" Text="Save" CssClass="btn btn-primary" />
        <asp:HiddenField runat="server" ID="hfId" Value="<%# Post.Id %>" />
    </p>
</asp:Content>