# .UserApi

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

# **apiUserBalanceGet**

> number apiUserBalanceGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:any = {};

apiInstance.apiUserBalanceGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**number**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiUserDeleteAllDelete**

> boolean apiUserDeleteAllDelete()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:any = {};

apiInstance.apiUserDeleteAllDelete(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**boolean**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiUserExportDataGet**

> UserTransactionsDto apiUserExportDataGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:any = {};

apiInstance.apiUserExportDataGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**UserTransactionsDto**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiUserFilteredTransactionsGet**

> UserTransactionsDto apiUserFilteredTransactionsGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:.UserApiApiUserFilteredTransactionsGetRequest = {
  // Array<number> (optional)
  categories: [
    1,
  ],
  // Date (optional)
  dateFrom: new Date('1970-01-01T00:00:00.00Z'),
  // Date (optional)
  dateTo: new Date('1970-01-01T00:00:00.00Z'),
};

apiInstance.apiUserFilteredTransactionsGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name           | Type                    | Description | Notes                            
----------------|-------------------------|-------------|----------------------------------
 **categories** | **Array&lt;number&gt;** |             | (optional) defaults to undefined 
 **dateFrom**   | [**Date**]              |             | (optional) defaults to undefined 
 **dateTo**     | [**Date**]              |             | (optional) defaults to undefined 

### Return type

**UserTransactionsDto**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiUserGet**

> UserDto apiUserGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:any = {};

apiInstance.apiUserGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**UserDto**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiUserImportDataPost**

> boolean apiUserImportDataPost()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:.UserApiApiUserImportDataPostRequest = {
  // UserTransactionsDto (optional)
  userTransactionsDto: {
    userId: "userId_example",
    incomes: [
      {
        id: 1,
        amount: 3.14,
        description: "description_example",
        date: new Date('1970-01-01T00:00:00.00Z'),
        userId: "userId_example",
        categoryId: 1,
      },
    ],
    expenses: [
      {
        id: 1,
        amount: 3.14,
        description: "description_example",
        date: new Date('1970-01-01T00:00:00.00Z'),
        userId: "userId_example",
        categoryId: 1,
      },
    ],
    totalIncome: 3.14,
    totalExpense: 3.14,
    balance: 3.14,
  },
};

apiInstance.apiUserImportDataPost(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name                    | Type                    | Description | Notes 
-------------------------|-------------------------|-------------|-------
 **userTransactionsDto** | **UserTransactionsDto** |             |

### Return type

**boolean**

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

# **apiUserStatisticsGet**

> UserStatisticsDto apiUserStatisticsGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:any = {};

apiInstance.apiUserStatisticsGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**UserStatisticsDto**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiUserStatsGraphGet**

> MemoryStream apiUserStatsGraphGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:any = {};

apiInstance.apiUserStatsGraphGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**MemoryStream**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiUserTotalExpenseGet**

> number apiUserTotalExpenseGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:any = {};

apiInstance.apiUserTotalExpenseGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**number**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)

# **apiUserTotalIncomeGet**

> number apiUserTotalIncomeGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .UserApi(configuration);

let body:any = {};

apiInstance.apiUserTotalIncomeGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**number**

### Authorization

[Bearer](README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

### HTTP response details

| Status code | Description | Response headers |
|-------------|-------------|------------------|
 **200**     | Success     | -                |

[[Back to top]](#) [[Back to API list]](README.md#documentation-for-api-endpoints) [[Back to Model list]](README.md#documentation-for-models) [[Back to README]](README.md)


