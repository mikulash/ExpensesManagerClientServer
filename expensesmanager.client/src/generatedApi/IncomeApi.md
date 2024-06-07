# .IncomeApi

All URIs are relative to *http://localhost*

 Method                                                                | HTTP request                     | Description 
-----------------------------------------------------------------------|----------------------------------|-------------
 [**apiIncomeAddOrUpdatePost**](IncomeApi.md#apiIncomeAddOrUpdatePost) | **POST** /api/Income/AddOrUpdate |
 [**apiIncomeDelete**](IncomeApi.md#apiIncomeDelete)                   | **DELETE** /api/Income           |
 [**apiIncomeDeleteAllDelete**](IncomeApi.md#apiIncomeDeleteAllDelete) | **DELETE** /api/Income/DeleteAll |
 [**apiIncomeGet**](IncomeApi.md#apiIncomeGet)                         | **GET** /api/Income              |
 [**apiIncomeGetAllGet**](IncomeApi.md#apiIncomeGetAllGet)             | **GET** /api/Income/GetAll       |

# **apiIncomeAddOrUpdatePost**

> IncomeDto apiIncomeAddOrUpdatePost()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .IncomeApi(configuration);

let body:.IncomeApiApiIncomeAddOrUpdatePostRequest = {
  // IncomeDto (optional)
  incomeDto: {
    id: 1,
    amount: 3.14,
    description: "description_example",
    date: new Date('1970-01-01T00:00:00.00Z'),
    userId: "userId_example",
    categoryId: 1,
  },
};

apiInstance.apiIncomeAddOrUpdatePost(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name          | Type          | Description | Notes 
---------------|---------------|-------------|-------
 **incomeDto** | **IncomeDto** |             |

### Return type

**IncomeDto**

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

# **apiIncomeDelete**

> boolean apiIncomeDelete()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .IncomeApi(configuration);

let body:.IncomeApiApiIncomeDeleteRequest = {
  // number (optional)
  incomeId: 1,
};

apiInstance.apiIncomeDelete(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name         | Type         | Description | Notes                            
--------------|--------------|-------------|----------------------------------
 **incomeId** | [**number**] |             | (optional) defaults to undefined 

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

# **apiIncomeDeleteAllDelete**

> boolean apiIncomeDeleteAllDelete()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .IncomeApi(configuration);

let body:any = {};

apiInstance.apiIncomeDeleteAllDelete(body).then((data:any) => {
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

# **apiIncomeGet**

> IncomeDto apiIncomeGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .IncomeApi(configuration);

let body:.IncomeApiApiIncomeGetRequest = {
  // number (optional)
  id: 1,
};

apiInstance.apiIncomeGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name   | Type         | Description | Notes                            
--------|--------------|-------------|----------------------------------
 **id** | [**number**] |             | (optional) defaults to undefined 

### Return type

**IncomeDto**

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

# **apiIncomeGetAllGet**

> Array<IncomeDto> apiIncomeGetAllGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .IncomeApi(configuration);

let body:any = {};

apiInstance.apiIncomeGetAllGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**Array<IncomeDto>**

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


