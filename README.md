# C# Web API routing mixed with Angular Routing
Basically I wanted to use C# as my API and keep that routing in tact while mixing in Angular Routing to handle my views.
This repo serves as a working example of the tutorial below to create you own copy of this repo yourself.

# Stackoverflow.com Post
The link below is probably a much better example and the original question for this repos basis.
http://stackoverflow.com/questions/25320041/c-sharp-web-api-routing-mixed-with-angular-routing


# Tutorial
Basically you will want to start by altering your MVC RouteConfig.CS
```
// serves plain html
  routes.MapRoute(
       name: "DefaultViews",
       url: "view/{controller}/{action}/{id}",
       defaults: new { id = UrlParameter.Optional }
  );

  // Home Index page have ng-app
  routes.MapRoute(
      name: "AngularApp",
      url: "{*.}",
      defaults: new { controller = "Home", action = "Index" }
  );
```

Anytime you add a route you will add a method to serve the HTML page for that partial angular route. In our case
we are creating the route /Test() which will serve the HTML Partial test.html to the angular route /Tests.
```
public ActionResult Index()
{
    ViewBag.Title = "Home Page";

    return View();
}

// Our example is using a route called /tests and it goes here to grab the html for it.
public ActionResult Test()
{
    var result = new FilePathResult("~/Views/Home/test.html", "text/html");
    return result;
}
```

Set Layout to null in _ViewStart.cshtml
```
@{
    Layout = null;
}
```

That takes care of all the C# setup. The rest is angular stuff.
Create your angular routing...Notice the templateUrl is view/Home/test. 
Basically we are telling C# to go to public ActionResult Test() in the HomeController which will return to us 
``` var result = new FilePathResult("~/Views/Home/test.html", "text/html");```
```
app.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode({enabled: true, requireBase:false});
    $routeProvider
        .when("/Tests", { templateUrl: "view/Home/test", controller: "TestController", caseInsensitiveMatch: true })
        .otherwise({ redirectTo: "/" });
});
```

That is it in a nutshell. Forgive the poorly written tutorial. I think the code base explains it all, but I just
wanted to give a overview for the readme. 
