# .CategoryApi

All URIs are relative to *http://localhost*

 Method                                                                      | HTTP request                       | Description 
-----------------------------------------------------------------------------|------------------------------------|-------------
 [**apiCategoryAddOrUpdatePost**](CategoryApi.md#apiCategoryAddOrUpdatePost) | **POST** /api/Category/AddOrUpdate |
 [**apiCategoryDelete**](CategoryApi.md#apiCategoryDelete)                   | **DELETE** /api/Category           |
 [**apiCategoryGet**](CategoryApi.md#apiCategoryGet)                         | **GET** /api/Category              |
 [**apiCategoryGetAllGet**](CategoryApi.md#apiCategoryGetAllGet)             | **GET** /api/Category/GetAll       |

# **apiCategoryAddOrUpdatePost**

> CategoryDto apiCategoryAddOrUpdatePost()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .CategoryApi(configuration);

let body:.CategoryApiApiCategoryAddOrUpdatePostRequest = {
  // CategoryDto (optional)
  categoryDto: {
    id: 1,
    name: "name_example",
  },
};

apiInstance.apiCategoryAddOrUpdatePost(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name            | Type            | Description | Notes 
-----------------|-----------------|-------------|-------
 **categoryDto** | **CategoryDto** |             |

### Return type

**CategoryDto**

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

# **apiCategoryDelete**

> boolean apiCategoryDelete()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .CategoryApi(configuration);

let body:.CategoryApiApiCategoryDeleteRequest = {
  // number (optional)
  categoryId: 1,
};

apiInstance.apiCategoryDelete(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name           | Type         | Description | Notes                            
----------------|--------------|-------------|----------------------------------
 **categoryId** | [**number**] |             | (optional) defaults to undefined 

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

# **apiCategoryGet**

> CategoryDto apiCategoryGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .CategoryApi(configuration);

let body:.CategoryApiApiCategoryGetRequest = {
  // number (optional)
  id: 1,
};

apiInstance.apiCategoryGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

 Name   | Type         | Description | Notes                            
--------|--------------|-------------|----------------------------------
 **id** | [**number**] |             | (optional) defaults to undefined 

### Return type

**CategoryDto**

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

# **apiCategoryGetAllGet**

> Array<CategoryDto> apiCategoryGetAllGet()

### Example

```typescript
import {  } from '';
import * as fs from 'fs';

const configuration = .createConfiguration();
const apiInstance = new .CategoryApi(configuration);

let body:any = {};

apiInstance.apiCategoryGetAllGet(body).then((data:any) => {
  console.log('API called successfully. Returned data: ' + data);
}).catch((error:any) => console.error(error));
```

### Parameters

This endpoint does not need any parameter.

### Return type

**Array<CategoryDto>**

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


