/**
 * ExpensesManager API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * OpenAPI spec version: v1
 *
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

export class IncomeDto {
    static readonly discriminator: string | undefined = undefined;
    static readonly attributeTypeMap: Array<{ name: string, baseName: string, type: string, format: string }> = [
        {
            "name": "id",
            "baseName": "id",
            "type": "number",
            "format": "int32"
        },
        {
            "name": "amount",
            "baseName": "amount",
            "type": "number",
            "format": "double"
        },
        {
            "name": "description",
            "baseName": "description",
            "type": "string",
            "format": ""
        },
        {
            "name": "date",
            "baseName": "date",
            "type": "Date",
            "format": "date-time"
        },
        {
            "name": "userId",
            "baseName": "userId",
            "type": "string",
            "format": ""
        },
        {
            "name": "categoryId",
            "baseName": "categoryId",
            "type": "number",
            "format": "int32"
        }];
    'id'?: number;
    'amount'?: number;
    'description'?: string | null;
    'date'?: Date;
    'userId'?: string | null;
    'categoryId'?: number;

    public constructor() {
    }

    static getAttributeTypeMap() {
        return IncomeDto.attributeTypeMap;
    }
}

