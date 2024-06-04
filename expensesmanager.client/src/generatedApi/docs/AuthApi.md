# ExpensesManagerApi.AuthApi

All URIs are relative to *http://localhost*

 Method                                                    | HTTP request                | Description 
-----------------------------------------------------------|-----------------------------|-------------
 [**apiAuthLoginPost**](AuthApi.md#apiAuthLoginPost)       | **POST** /api/Auth/login    |
 [**apiAuthRegisterPost**](AuthApi.md#apiAuthRegisterPost) | **POST** /api/Auth/register |

## apiAuthLoginPost

> apiAuthLoginPost(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.AuthApi();
let opts = {
  'loginDto': new ExpensesManagerApi.LoginDto() // LoginDto | 
};
apiInstance.apiAuthLoginPost(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters

 Name         | Type                        | Description | Notes      
--------------|-----------------------------|-------------|------------
 **loginDto** | [**LoginDto**](LoginDto.md) |             | [optional] 

### Return type

null (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: Not defined

## apiAuthRegisterPost

> RegistrationSuccessDto apiAuthRegisterPost(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.AuthApi();
let opts = {
  'registrationDto': new ExpensesManagerApi.RegistrationDto() // RegistrationDto | 
};
apiInstance.apiAuthRegisterPost(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name                | Type                                      | Description | Notes      
---------------------|-------------------------------------------|-------------|------------
 **registrationDto** | [**RegistrationDto**](RegistrationDto.md) |             | [optional] 

### Return type

[**RegistrationSuccessDto**](RegistrationSuccessDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

