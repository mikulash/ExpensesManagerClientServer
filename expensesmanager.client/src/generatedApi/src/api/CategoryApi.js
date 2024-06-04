/**
 * ExpensesManager API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 *
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 *
 */


import ApiClient from "../ApiClient";
import CategoryDto from '../model/CategoryDto';

/**
 * Category service.
 * @module api/CategoryApi
 * @version v1
 */
export default class CategoryApi {

    /**
     * Constructs a new CategoryApi.
     * @alias module:api/CategoryApi
     * @class
     * @param {module:ApiClient} [apiClient] Optional API client implementation to use,
     * default to {@link module:ApiClient#instance} if unspecified.
     */
    constructor(apiClient) {
        this.apiClient = apiClient || ApiClient.instance;
    }


    /**
     * Callback function to receive the result of the apiCategoryAddOrUpdatePost operation.
     * @callback module:api/CategoryApi~apiCategoryAddOrUpdatePostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/CategoryDto} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:model/CategoryDto} [categoryDto]
     * @param {module:api/CategoryApi~apiCategoryAddOrUpdatePostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/CategoryDto}
     */
    apiCategoryAddOrUpdatePost(opts, callback) {
        opts = opts || {};
        let postBody = opts['categoryDto'];

        let pathParams = {};
        let queryParams = {};
        let headerParams = {};
        let formParams = {};

        let authNames = ['Bearer'];
        let contentTypes = ['application/json', 'text/json', 'application/*+json'];
        let accepts = ['text/plain', 'application/json', 'text/json'];
        let returnType = CategoryDto;
        return this.apiClient.callApi(
            '/api/Category/AddOrUpdate', 'POST',
            pathParams, queryParams, headerParams, formParams, postBody,
            authNames, contentTypes, accepts, returnType, null, callback
        );
    }

    /**
     * Callback function to receive the result of the apiCategoryDelete operation.
     * @callback module:api/CategoryApi~apiCategoryDeleteCallback
     * @param {String} error Error message, if any.
     * @param {Boolean} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {Number} [categoryId]
     * @param {module:api/CategoryApi~apiCategoryDeleteCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link Boolean}
     */
    apiCategoryDelete(opts, callback) {
        opts = opts || {};
        let postBody = null;

        let pathParams = {};
        let queryParams = {
            'categoryId': opts['categoryId']
        };
        let headerParams = {};
        let formParams = {};

        let authNames = ['Bearer'];
        let contentTypes = [];
        let accepts = ['text/plain', 'application/json', 'text/json'];
        let returnType = 'Boolean';
        return this.apiClient.callApi(
            '/api/Category', 'DELETE',
            pathParams, queryParams, headerParams, formParams, postBody,
            authNames, contentTypes, accepts, returnType, null, callback
        );
    }

    /**
     * Callback function to receive the result of the apiCategoryGet operation.
     * @callback module:api/CategoryApi~apiCategoryGetCallback
     * @param {String} error Error message, if any.
     * @param {module:model/CategoryDto} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {Number} [id]
     * @param {module:api/CategoryApi~apiCategoryGetCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/CategoryDto}
     */
    apiCategoryGet(opts, callback) {
        opts = opts || {};
        let postBody = null;

        let pathParams = {};
        let queryParams = {
            'id': opts['id']
        };
        let headerParams = {};
        let formParams = {};

        let authNames = ['Bearer'];
        let contentTypes = [];
        let accepts = ['text/plain', 'application/json', 'text/json'];
        let returnType = CategoryDto;
        return this.apiClient.callApi(
            '/api/Category', 'GET',
            pathParams, queryParams, headerParams, formParams, postBody,
            authNames, contentTypes, accepts, returnType, null, callback
        );
    }

    /**
     * Callback function to receive the result of the apiCategoryGetAllGet operation.
     * @callback module:api/CategoryApi~apiCategoryGetAllGetCallback
     * @param {String} error Error message, if any.
     * @param {Array.<module:model/CategoryDto>} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {module:api/CategoryApi~apiCategoryGetAllGetCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link Array.<module:model/CategoryDto>}
     */
    apiCategoryGetAllGet(callback) {
        let postBody = null;

        let pathParams = {};
        let queryParams = {};
        let headerParams = {};
        let formParams = {};

        let authNames = ['Bearer'];
        let contentTypes = [];
        let accepts = ['text/plain', 'application/json', 'text/json'];
        let returnType = [CategoryDto];
        return this.apiClient.callApi(
            '/api/Category/GetAll', 'GET',
            pathParams, queryParams, headerParams, formParams, postBody,
            authNames, contentTypes, accepts, returnType, null, callback
        );
    }


}
