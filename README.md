# Matech.Common.Scaffolding.Api

Template project for .net core 3.1 Api

---

## Build & debug

If usign VS Code:

* Press F5 to configure a build tasks.
* Press F5 again to run the project in debug mode.

Open [https://localhost:5001/api/v1/tests](https://localhost:5001/api/v1/tests) in your favorite browser.

## Build for production

This project is aimed to be deployed in a containerized way.

```
docker build -t matech-api-sample .
docker run -d -p 5001:5001 --name matech-api-sample matech-api-sample
```

