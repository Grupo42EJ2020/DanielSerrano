<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVCLaboratorio.Models.Employee>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>EmployeeRead</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            <th>Id: </th>
            <th>Name: </th>
            <th>Address: </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "EmployeeEdit", new { id=item.IdEmployee}) %> |
                <%: Html.ActionLink("Details", "EmployeeDetails", new { id=item.IdEmployee })%> |
                <%: Html.ActionLink("Delete", "EmployeeDelete", new { id = item.IdEmployee })%>
            </td>
            <td><%: item.IdEmployee %></td>
            <td><%: item.Name  %></td>
            <td><%: item.Address  %></td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "EmployeeCreate") %>
    </p>

</body>
</html>

