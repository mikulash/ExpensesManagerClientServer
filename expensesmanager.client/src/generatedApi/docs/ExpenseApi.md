# ExpensesManagerApi.ExpenseApi

All URIs are relative to *http://localhost*

 Method                                                                           | HTTP request                          | Description 
----------------------------------------------------------------------------------|---------------------------------------|-------------
 [**apiExpenseAddOrUpdatePost**](ExpenseApi.md#apiExpenseAddOrUpdatePost)         | **POST** /api/Expense/AddOrUpdate     |
 [**apiExpenseDelete**](ExpenseApi.md#apiExpenseDelete)                           | **DELETE** /api/Expense               |
 [**apiExpenseGet**](ExpenseApi.md#apiExpenseGet)                                 | **GET** /api/Expense                  |
 [**apiExpenseGetAllGet**](ExpenseApi.md#apiExpenseGetAllGet)                     | **GET** /api/Expense/GetAll           |
 [**apiExpenseGetByAmountRangeGet**](ExpenseApi.md#apiExpenseGetByAmountRangeGet) | **GET** /api/Expense/GetByAmountRange |
 [**apiExpenseGetByCategoryGet**](ExpenseApi.md#apiExpenseGetByCategoryGet)       | **GET** /api/Expense/GetByCategory    |
 [**apiExpenseGetByDateRangeGet**](ExpenseApi.md#apiExpenseGetByDateRangeGet)     | **GET** /api/Expense/GetByDateRange   |

## apiExpenseAddOrUpdatePost

> ExpenseDto apiExpenseAddOrUpdatePost(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.ExpenseApi();
let opts = {
  'expenseDto': new ExpensesManagerApi.ExpenseDto() // ExpenseDto | 
};
apiInstance.apiExpenseAddOrUpdatePost(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name           | Type                            | Description | Notes      
----------------|---------------------------------|-------------|------------
 **expenseDto** | [**ExpenseDto**](ExpenseDto.md) |             | [optional] 

### Return type

[**ExpenseDto**](ExpenseDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

## apiExpenseDelete

> Boolean apiExpenseDelete(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.ExpenseApi();
let opts = {
  'expenseId': 56 // Number | 
};
apiInstance.apiExpenseDelete(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name          | Type       | Description | Notes      
---------------|------------|-------------|------------
 **expenseId** | **Number** |             | [optional] 

### Return type

**Boolean**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiExpenseGet

> ExpenseDto apiExpenseGet(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.ExpenseApi();
let opts = {
  'id': 56 // Number | 
};
apiInstance.apiExpenseGet(opts, (error, data, response) => {
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

[**ExpenseDto**](ExpenseDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiExpenseGetAllGet

> [ExpenseDto] apiExpenseGetAllGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.ExpenseApi();
apiInstance.apiExpenseGetAllGet((error, data, response) => {
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

[**[ExpenseDto]**](ExpenseDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiExpenseGetByAmountRangeGet

> [ExpenseDto] apiExpenseGetByAmountRangeGet(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.ExpenseApi();
let opts = {
  'minAmount': 3.4, // Number | 
  'maxAmount': 3.4 // Number | 
};
apiInstance.apiExpenseGetByAmountRangeGet(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name          | Type       | Description | Notes      
---------------|------------|-------------|------------
 **minAmount** | **Number** |             | [optional] 
 **maxAmount** | **Number** |             | [optional] 

### Return type

[**[ExpenseDto]**](ExpenseDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiExpenseGetByCategoryGet

> [ExpenseDto] apiExpenseGetByCategoryGet(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.ExpenseApi();
let opts = {
  'categoryId': 56 // Number | 
};
apiInstance.apiExpenseGetByCategoryGet(opts, (error, data, response) => {
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

[**[ExpenseDto]**](ExpenseDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiExpenseGetByDateRangeGet

> [ExpenseDto] apiExpenseGetByDateRangeGet(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.ExpenseApi();
let opts = {
  'startDate': new Date("2013-10-20T19:20:30+01:00"), // Date | 
  'endDate': new Date("2013-10-20T19:20:30+01:00") // Date | 
};
apiInstance.apiExpenseGetByDateRangeGet(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name          | Type     | Description | Notes      
---------------|----------|-------------|------------
 **startDate** | **Date** |             | [optional] 
 **endDate**   | **Date** |             | [optional] 

### Return type

[**[ExpenseDto]**](ExpenseDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

