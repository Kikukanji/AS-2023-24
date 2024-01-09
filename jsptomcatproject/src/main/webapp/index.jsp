<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Convertitore</title>
</head>
<body>
<form method="GET" action="output.jsp">
	<input type="number" id="number" name="n"><br>
	<select name="base">
		<option value="10">convert into</option>
		<option value="2">BINARIO</option>
		<option value="8">OTTALE</option>
		<option value="16">ESADECIMALE</option>
	</select>
	<input type="submit" value="convert"/>
</form>
</body>
</html>