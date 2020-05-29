<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVCLaboratorio.Models.Employee>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>EmployeeDetails</title>
</head>
<body>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">IdEmployee</div>
        <div class="display-field"><%: Model.IdEmployee %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
        <div class="display-label">Address</div>
        <div class="display-field"><%: Model.Address %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "EmployeeEdit", new { id=Model.IdEmployee }) %> |
        <%: Html.ActionLink("Back to List", "EmployeeRead") %>
    </p>

</body>
</html>

