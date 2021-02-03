Configure auth parameters in Startup.cs.

This sample works with the Standard Authentication Flow.

Client ID: sample-web-app
Client Protocol: openid-connect
Access Type: confidential
Standard Flow Enabled: ON
Valid Redirect URLs: http://localhost:5232/*

{
  "realm": "example",
  "auth-server-url": "https://example.com/auth",
  "ssl-required": "none",
  "resource": "sample-web-app",
  "credentials": {
    "secret": "bc602d51-76ef-4b6c-94ed-2fdf3c2a67f1"
  }
}