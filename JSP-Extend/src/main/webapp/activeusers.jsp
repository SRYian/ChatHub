<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
    <script src="https://cdn.tailwindcss.com"></script>
    <link type="text/css" rel="stylesheet" href="${pageContext.request.contextPath}/css/site.css" >
</head>
<body>

    <header>
        <nav class="relative flex flex-wrap items-center content-between py-3 px-4  navbar-toggleable-sm border-bottom-orange box-shadow mb-3">
            <div class="container mx-auto sm:px-4">
                <div class="flex h-100 v-100 flex-row-reverse justify-between">
                    <ul class="flex flex-wrap list-reset pl-0 mb-0">

                        <li class="">
                            <a class="inline-block py-2 px-4 no-underline text-orange" asp-controller="User" asp-action="Register">Register</a>
                        </li>
                
                        <li class="">
                            <a class="inline-block py-2 px-4 no-underline text-orange" asp-area="" asp-controller="User" asp-action="Login">Login</a>
                        </li>
                    
                    </ul>
                    <ul class="flex flex-wrap list-reset pl-0 mb-0 flex-grow-1">
                        <li class="">
                            <a class="inline-block py-2 px-4 no-underline text-gray-100">Home</a>
                        </li>
                     
                        <li class="">
                            <a class="inline-block py-2 px-4 no-underline text-gray-100">Chat</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <div class="flex flex-col h-screen h- max-w-screen w-full justify-center items-center">
        <h3 class="text-gray-50 p-4" >All Users:</h3>
        <ul class="max-w-md list-none text-gray-50 m-4 space-y-3">
            <c:forEach items="${users}" var="item">
                <li class="py-2 px-4 bg-col-secondary rounded-md">${item}</li>
            </c:forEach>
        </ul>
    </div>
    <div class="flex flex-col h-screen h- max-w-screen w-full justify-center items-center">
        <h3 class="text-gray-50 p-4" >All messages:</h3>
        <ul class="max-w-md list-none text-gray-50 m-4 space-y-3">
            <c:forEach items="${messages}" var="item">
                <li class="py-2 px-4 bg-col-secondary rounded-md">${item}</li>
            </c:forEach>
        </ul>
    </div>
</body>
</html>
