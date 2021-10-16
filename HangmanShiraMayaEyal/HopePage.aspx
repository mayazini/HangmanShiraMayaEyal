<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HopePage.aspx.cs" Inherits="HangmanShiraMayaEyal.HopePage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         
    <div>
        <img src="images/shiraMayaEyalPic.PNG" />
    </div>
    <asp:Repeater ID="Rept" runat="server">
    <HeaderTemplate>
    <ul>
    </HeaderTemplate>
    <ItemTemplate>
    <li><a href="HangManGame.aspx?CategoryId=<%#Eval("Id") %>"><%#Eval("CategoryName") %></a></li>
    </ItemTemplate>
    <FooterTemplate>
    </ul>
    </FooterTemplate>
        </asp:Repeater>
</asp:Content>
