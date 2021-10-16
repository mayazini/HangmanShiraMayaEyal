<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HangmanGame.aspx.cs" Inherits="HangmanShiraMayaEyal.HangmanGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <%=randWord %>
   <input type="text" id="guessedLetter" name="guessedLetter" placeholder="enter a letter"/>
    <input type="submit" name="btnsubmit" id="btnsubmit" class="btn btn-secondary" placeholder="try">
</asp:Content>
