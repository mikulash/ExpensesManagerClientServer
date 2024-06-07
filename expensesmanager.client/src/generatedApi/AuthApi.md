# .AuthApi

All URIs are relative to *http://localhost*

 Method                                                    | HTTP request                | Description 
-----------------------------------------------------------|-----------------------------|-------------
 [**apiAuthLoginPost**](AuthApi.md#apiAuthLoginPost)       | **POST** /api/Auth/login    |
 [**apiAuthRegisterPost**](AuthApi.md#apiAuthRegisterPost) | **POST** /api/Auth/register |

# **apiAuthLoginPost**

> void apiAuthLoginPost()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .AuthApi(configuration);

let body:.AuthApiApiAuthLoginPostRequest = {
  // LoginDto (optional)
  loginDto: {
    email: "email_example",
    password: "password_example",
    rememberMe: true,
  },
};

apiInstance.apiAuthLoginPost(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name         | Type         | Description | Notes 
--------------|--------------|-------------|-------
 **loginDto** | **LoginDto** |             |

### Return type

**void**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: Not defined

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiAuthRegisterPost**

> RegistrationSuccessDto apiAuthRegisterPost()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .AuthApi(configuration);

let body:.AuthApiApiAuthRegisterPostRequest = {
  // RegistrationDto (optional)
  registrationDto: {
    email: "email_example",
    password: "password_example",
    confirmPassword: "confirmPassword_example",
  },
};

apiInstance.apiAuthRegisterPost(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name                | Type                | Description | Notes 
---------------------|---------------------|-------------|-------
 **registrationDto** | **RegistrationDto** |             |

### Return type

**RegistrationSuccessDto**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)


