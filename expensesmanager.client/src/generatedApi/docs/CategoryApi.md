# ExpensesManagerApi.CategoryApi

All URIs are relative to *http://localhost*

 Method                                                                      | HTTP request                       | Description 
-----------------------------------------------------------------------------|------------------------------------|-------------
 [**apiCategoryAddOrUpdatePost**](CategoryApi.md#apiCategoryAddOrUpdatePost) | **POST** /api/Category/AddOrUpdate |
 [**apiCategoryDelete**](CategoryApi.md#apiCategoryDelete)                   | **DELETE** /api/Category           |
 [**apiCategoryGet**](CategoryApi.md#apiCategoryGet)                         | **GET** /api/Category              |
 [**apiCategoryGetAllGet**](CategoryApi.md#apiCategoryGetAllGet)             | **GET** /api/Category/GetAll       |

## apiCategoryAddOrUpdatePost

> CategoryDto apiCategoryAddOrUpdatePost(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.CategoryApi();
let opts = {
  'categoryDto': new ExpensesManagerApi.CategoryDto() // CategoryDto | 
};
apiInstance.apiCategoryAddOrUpdatePost(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name            | Type                              | Description | Notes      
-----------------|-----------------------------------|-------------|------------
 **categoryDto** | [**CategoryDto**](CategoryDto.md) |             | [optional] 

### Return type

[**CategoryDto**](CategoryDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

## apiCategoryDelete

> Boolean apiCategoryDelete(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.CategoryApi();
let opts = {
  'categoryId': 56 // Number | 
};
apiInstance.apiCategoryDelete(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name           | Type       | Description | Notes      
----------------|------------|-------------|------------
 **categoryId** | **Number** |             | [optional] 

### Return type

**Boolean**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiCategoryGet

> CategoryDto apiCategoryGet(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.CategoryApi();
let opts = {
  'id': 56 // Number | 
};
apiInstance.apiCategoryGet(opts, (error, data, response) => {
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

[**CategoryDto**](CategoryDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiCategoryGetAllGet

> [CategoryDto] apiCategoryGetAllGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.CategoryApi();
apiInstance.apiCategoryGetAllGet((error, data, response) => {
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

[**[CategoryDto]**](CategoryDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

