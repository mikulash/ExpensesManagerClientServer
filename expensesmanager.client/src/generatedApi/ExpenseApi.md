# .ExpenseApi

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

# **apiExpenseAddOrUpdatePost**

> ExpenseDto apiExpenseAddOrUpdatePost()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .ExpenseApi(configuration);

let body:.ExpenseApiApiExpenseAddOrUpdatePostRequest = {
  // ExpenseDto (optional)
  expenseDto: {
    id: 1,
    amount: 3.14,
    description: "description_example",
    date: new Date('1970-01-01T00:00:00.00Z'),
    userId: "userId_example",
    categoryId: 1,
  },
};

apiInstance.apiExpenseAddOrUpdatePost(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name           | Type           | Description | Notes 
----------------|----------------|-------------|-------
 **expenseDto** | **ExpenseDto** |             |

### Return type

**ExpenseDto**

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

# **apiExpenseDelete**

> boolean apiExpenseDelete()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .ExpenseApi(configuration);

let body:.ExpenseApiApiExpenseDeleteRequest = {
  // number (optional)
  expenseId: 1,
};

apiInstance.apiExpenseDelete(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name          | Type         | Description | Notes                            
---------------|--------------|-------------|----------------------------------
 **expenseId** | [**number**] |             | (optional) defaults to undefined 

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

# **apiExpenseGet**

> ExpenseDto apiExpenseGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .ExpenseApi(configuration);

let body:.ExpenseApiApiExpenseGetRequest = {
  // number (optional)
  id: 1,
};

apiInstance.apiExpenseGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name   | Type         | Description | Notes                            
--------|--------------|-------------|----------------------------------
 **id** | [**number**] |             | (optional) defaults to undefined 

### Return type

**ExpenseDto**

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

# **apiExpenseGetAllGet**

> Array<ExpenseDto> apiExpenseGetAllGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .ExpenseApi(configuration);

let body:any = {};

apiInstance.apiExpenseGetAllGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**Array<ExpenseDto>**

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

# **apiExpenseGetByAmountRangeGet**

> Array<ExpenseDto> apiExpenseGetByAmountRangeGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .ExpenseApi(configuration);

let body:.ExpenseApiApiExpenseGetByAmountRangeGetRequest = {
  // number (optional)
  minAmount: 3.14,
  // number (optional)
  maxAmount: 3.14,
};

apiInstance.apiExpenseGetByAmountRangeGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name          | Type         | Description | Notes                            
---------------|--------------|-------------|----------------------------------
 **minAmount** | [**number**] |             | (optional) defaults to undefined 
 **maxAmount** | [**number**] |             | (optional) defaults to undefined 

### Return type

**Array<ExpenseDto>**

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

# **apiExpenseGetByCategoryGet**

> Array<ExpenseDto> apiExpenseGetByCategoryGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .ExpenseApi(configuration);

let body:.ExpenseApiApiExpenseGetByCategoryGetRequest = {
  // number (optional)
  categoryId: 1,
};

apiInstance.apiExpenseGetByCategoryGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name           | Type         | Description | Notes                            
----------------|--------------|-------------|----------------------------------
 **categoryId** | [**number**] |             | (optional) defaults to undefined 

### Return type

**Array<ExpenseDto>**

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

# **apiExpenseGetByDateRangeGet**

> Array<ExpenseDto> apiExpenseGetByDateRangeGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .ExpenseApi(configuration);

let body:.ExpenseApiApiExpenseGetByDateRangeGetRequest = {
  // Date (optional)
  startDate: new Date('1970-01-01T00:00:00.00Z'),
  // Date (optional)
  endDate: new Date('1970-01-01T00:00:00.00Z'),
};

apiInstance.apiExpenseGetByDateRangeGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name          | Type       | Description | Notes                            
---------------|------------|-------------|----------------------------------
 **startDate** | [**Date**] |             | (optional) defaults to undefined 
 **endDate**   | [**Date**] |             | (optional) defaults to undefined 

### Return type

**Array<ExpenseDto>**

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


