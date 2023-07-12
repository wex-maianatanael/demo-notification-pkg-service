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

ℹ️ You can use the above json as payload or just pass an empty json to send the request. If you send and empty json, the model class you use the default values for each property.

### API Response

<img width="715" alt="image" src="https://github.com/wex-maianatanael/demo-notification-pkg-service/assets/97063562/b701d886-19c3-4ccb-bceb-ef67e78611ec">
