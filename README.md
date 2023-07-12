# demo-notification-pkg-service

This demo shows how to use the notification pkg to send emails through the notification service.

### API endpoint payload:

```
{
  "from": "no-reply@wexedge.com",
  "tos": [
    "your.email@wexinc.com"
  ],
  "subject": "test",
  "contents": [
    {
      "type": "TEXT",
      "value": "this is a email sending test"
    }
  ]
}
```

ℹ️ You can use the above json as payload or just pass an empty json `{}` to send the request. If you send an empty json, the model class will use the default values for each property.

⚠️ The `"from":` attribute must have the `"no-reply@wexedge.com"` value assigned, otherwise it's not gonna work.

### API Response

<img width="715" alt="image" src="https://github.com/wex-maianatanael/demo-notification-pkg-service/assets/97063562/b701d886-19c3-4ccb-bceb-ef67e78611ec">

### Email received

<img width="236" alt="image" src="https://github.com/wex-maianatanael/demo-notification-pkg-service/assets/97063562/85039e3a-f89c-4ac0-a8b0-fae3213c572a">
