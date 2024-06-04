# ExpensesManagerApi.IncomeApi

All URIs are relative to *http://localhost*

 Method                                                                | HTTP request                     | Description 
-----------------------------------------------------------------------|----------------------------------|-------------
 [**apiIncomeAddOrUpdatePost**](IncomeApi.md#apiIncomeAddOrUpdatePost) | **POST** /api/Income/AddOrUpdate |
 [**apiIncomeDelete**](IncomeApi.md#apiIncomeDelete)                   | **DELETE** /api/Income           |
 [**apiIncomeDeleteAllDelete**](IncomeApi.md#apiIncomeDeleteAllDelete) | **DELETE** /api/Income/DeleteAll |
 [**apiIncomeGet**](IncomeApi.md#apiIncomeGet)                         | **GET** /api/Income              |
 [**apiIncomeGetAllGet**](IncomeApi.md#apiIncomeGetAllGet)             | **GET** /api/Income/GetAll       |

## apiIncomeAddOrUpdatePost

> IncomeDto apiIncomeAddOrUpdatePost(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.IncomeApi();
let opts = {
  'incomeDto': new ExpensesManagerApi.IncomeDto() // IncomeDto | 
};
apiInstance.apiIncomeAddOrUpdatePost(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name          | Type                          | Description | Notes      
---------------|-------------------------------|-------------|------------
 **incomeDto** | [**IncomeDto**](IncomeDto.md) |             | [optional] 

### Return type

[**IncomeDto**](IncomeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

## apiIncomeDelete

> Boolean apiIncomeDelete(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.IncomeApi();
let opts = {
  'incomeId': 56 // Number | 
};
apiInstance.apiIncomeDelete(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name         | Type       | Description | Notes      
--------------|------------|-------------|------------
 **incomeId** | **Number** |             | [optional] 

### Return type

**Boolean**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiIncomeDeleteAllDelete

> Boolean apiIncomeDeleteAllDelete()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.IncomeApi();
apiInstance.apiIncomeDeleteAllDelete((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

**Boolean**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiIncomeGet

> IncomeDto apiIncomeGet(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.IncomeApi();
let opts = {
  'id': 56 // Number | 
};
apiInstance.apiIncomeGet(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name   | Type       | Description | Notes      
--------|------------|-------------|------------
 **id** | **Number** |             | [optional] 

### Return type

[**IncomeDto**](IncomeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiIncomeGetAllGet

> [IncomeDto] apiIncomeGetAllGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.IncomeApi();
apiInstance.apiIncomeGetAllGet((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**[IncomeDto]**](IncomeDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

