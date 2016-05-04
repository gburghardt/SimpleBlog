<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to my Blog!</h1>
        <p class="lead">Lots of stuff to read</p>
    </div>

    <ol class="list-unstyled">
        <asp:Repeater ID="BlogPostList" runat="server" DataSource="<%# this.BlogPosts %>">
            <ItemTemplate>
                <li>
                    <h1>
                        <%# DataBinder.Eval(Container.DataItem, "Title") %>
                        <small>[<a href="BlogPostForm.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Id") %>">Edit</a>]</small>
                    </h1>
                    <p><%# DataBinder.Eval(Container.DataItem, "PublishDate") %></p>
                    <p><%# DataBinder.Eval(Container.DataItem, "Body") %></p>
                    <hr />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ol>

    <p>
        <a href="BlogPostForm.aspx" class="btn btn-primary">Create New Blog Post</a>
    </p>
</asp:Content>
