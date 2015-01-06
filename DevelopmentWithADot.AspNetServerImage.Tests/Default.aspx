<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="DevelopmentWithADot.AspNetServerImage.Tests.Default" %>
<%@ Register TagPrefix="web" Namespace="DevelopmentWithADot.AspNetServerImage" Assembly="DevelopmentWithADot.AspNetServerImage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form runat="server">
	<div>
		<web:ServerImage runat="server" id="image" width="200px" height="100px" ondraw="OnDraw" />
	</div>
	</form>
</body>
</html>
