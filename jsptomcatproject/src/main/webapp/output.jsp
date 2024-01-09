<%@ page import="model.BaseConvert" %>
<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %><!DOCTYPE html>
<%
int n = Integer.parseInt(request.getParameter("n"));
int base = Integer.parseInt(request.getParameter("base"));
String outputResult = "";
if(base == 16) {
	outputResult = "%X".formatted(n);
} else if(base == 8) {
	outputResult = "%o".formatted(n);
} else if(base == 2) {
	outputResult = BaseConvert.toBinary(n);
} else {
	outputResult = "%d".formatted(n);
}
%>
<html>
<head>
<meta charset="UTF-8"/>
<title>Convertitore</title>
</head>
<body>
<%= n %><sub><%= base %></sub> = <%= outputResult %>
</body>
</html>