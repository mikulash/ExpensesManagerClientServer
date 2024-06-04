# ExpensesManagerApi.UserApi

All URIs are relative to *http://localhost*

 Method                                                                          | HTTP request                           | Description 
---------------------------------------------------------------------------------|----------------------------------------|-------------
 [**apiUserBalanceGet**](UserApi.md#apiUserBalanceGet)                           | **GET** /api/User/Balance              |
 [**apiUserDeleteAllDelete**](UserApi.md#apiUserDeleteAllDelete)                 | **DELETE** /api/User/DeleteAll         |
 [**apiUserExportDataGet**](UserApi.md#apiUserExportDataGet)                     | **GET** /api/User/ExportData           |
 [**apiUserFilteredTransactionsGet**](UserApi.md#apiUserFilteredTransactionsGet) | **GET** /api/User/FilteredTransactions |
 [**apiUserGet**](UserApi.md#apiUserGet)                                         | **GET** /api/User                      |
 [**apiUserImportDataPost**](UserApi.md#apiUserImportDataPost)                   | **POST** /api/User/ImportData          |
 [**apiUserStatisticsGet**](UserApi.md#apiUserStatisticsGet)                     | **GET** /api/User/Statistics           |
 [**apiUserStatsGraphGet**](UserApi.md#apiUserStatsGraphGet)                     | **GET** /api/User/StatsGraph           |
 [**apiUserTotalExpenseGet**](UserApi.md#apiUserTotalExpenseGet)                 | **GET** /api/User/TotalExpense         |
 [**apiUserTotalIncomeGet**](UserApi.md#apiUserTotalIncomeGet)                   | **GET** /api/User/TotalIncome          |

## apiUserBalanceGet

> Number apiUserBalanceGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
apiInstance.apiUserBalanceGet((error, data, response) => {
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

**Number**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiUserDeleteAllDelete

> Boolean apiUserDeleteAllDelete()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
apiInstance.apiUserDeleteAllDelete((error, data, response) => {
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

## apiUserExportDataGet

> UserTransactionsDto apiUserExportDataGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
apiInstance.apiUserExportDataGet((error, data, response) => {
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

[**UserTransactionsDto**](UserTransactionsDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiUserFilteredTransactionsGet

> UserTransactionsDto apiUserFilteredTransactionsGet(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
let opts = {
  'categories': [null], // [Number] | 
  'dateFrom': new Date("2013-10-20T19:20:30+01:00"), // Date | 
  'dateTo': new Date("2013-10-20T19:20:30+01:00") // Date | 
};
apiInstance.apiUserFilteredTransactionsGet(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name           | Type                      | Description | Notes      
----------------|---------------------------|-------------|------------
 **categories** | [**[Number]**](Number.md) |             | [optional] 
 **dateFrom**   | **Date**                  |             | [optional] 
 **dateTo**     | **Date**                  |             | [optional] 

### Return type

[**UserTransactionsDto**](UserTransactionsDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiUserGet

> UserDto apiUserGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
apiInstance.apiUserGet((error, data, response) => {
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

[**UserDto**](UserDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiUserImportDataPost

> Boolean apiUserImportDataPost(opts)

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
let opts = {
  'userTransactionsDto': new ExpensesManagerApi.UserTransactionsDto() // UserTransactionsDto | 
};
apiInstance.apiUserImportDataPost(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

 Name                    | Type                                              | Description | Notes      
-------------------------|---------------------------------------------------|-------------|------------
 **userTransactionsDto** | [**UserTransactionsDto**](UserTransactionsDto.md) |             | [optional] 

### Return type

**Boolean**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

## apiUserStatisticsGet

> UserStatisticsDto apiUserStatisticsGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
apiInstance.apiUserStatisticsGet((error, data, response) => {
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

[**UserStatisticsDto**](UserStatisticsDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiUserStatsGraphGet

> MemoryStream apiUserStatsGraphGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
apiInstance.apiUserStatsGraphGet((error, data, response) => {
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

[**MemoryStream**](MemoryStream.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiUserTotalExpenseGet

> Number apiUserTotalExpenseGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
apiInstance.apiUserTotalExpenseGet((error, data, response) => {
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

**Number**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

## apiUserTotalIncomeGet

> Number apiUserTotalIncomeGet()

### Example

```javascript
import ExpensesManagerApi from 'expenses_manager_api';
let defaultClient = ExpensesManagerApi.ApiClient.instance;
// Configure Bearer (JWT) access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new ExpensesManagerApi.UserApi();
apiInstance.apiUserTotalIncomeGet((error, data, response) => {
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

**Number**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

