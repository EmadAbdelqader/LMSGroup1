<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="LMSGroup1.Web.Users.UsersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <h2>Users List</h2>

        <!-- Search Criteria -->
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="txtUserID">User ID</label>
                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="txtFirstName">First Name</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="txtFirstName">Is Deleted</label>
                    <asp:DropDownList ID="ddlIsDeleted" runat="server" CssClass="form-control">
                        <asp:ListItem Value="-1" Text="All" />
                        <asp:ListItem Value="1" Text="Yes" />
                        <asp:ListItem Value="0" Text="No" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <!-- Actions -->
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button CssClass="btn btn-danger" ID="btSearch" runat="server" Text="Search" OnClick="btSearch_Click"  />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btAddNew" runat="server" Text="Add New User" CssClass="btn btn-success" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:ListView ID="lvUsers" runat="server" DataKeyNames="UserId">
                    <LayoutTemplate>
                        <table class="table table-condensed table-striped">
                            <thead>
                                <th>User Id</th>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Username</th>
                                <th>Is Active</th>
                                <th>Is Deleted</th>
                                <th>Created On</th>
                                <th>Updated On</th>
                                <th>Actions</th>
                            </thead>
                            <tbody>
                               <tr id="itemPlaceHolder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><asp:Label runat="server" ID="lblUserId" Text='<%# Bind("UserId") %>' /></td>
                            <td><%# Eval("FirstName") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><%# Eval("Username") %></td>
                            <td><%# Eval("IsActive") %></td>
                            <td><%# Eval("IsDeleted") %></td>
                            <td><%# Eval("CreatedOn") %></td>
                            <td><%# Eval("UpdatedOn") %></td>
                            <td>
                                ..
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td>No Data available.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:ListView>


            </div>
        </div>

    </div>
</asp:Content>
