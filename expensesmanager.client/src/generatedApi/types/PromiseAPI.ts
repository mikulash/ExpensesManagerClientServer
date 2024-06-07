import {HttpInfo} from '../http/http';
import {Configuration} from '../configuration'
import {CategoryDto} from '../models/CategoryDto';
import {ExpenseDto} from '../models/ExpenseDto';
import {IncomeDto} from '../models/IncomeDto';
import {LoginDto} from '../models/LoginDto';
import {MemoryStream} from '../models/MemoryStream';
import {RegistrationDto} from '../models/RegistrationDto';
import {RegistrationSuccessDto} from '../models/RegistrationSuccessDto';
import {UserDto} from '../models/UserDto';
import {UserStatisticsDto} from '../models/UserStatisticsDto';
import {UserTransactionsDto} from '../models/UserTransactionsDto';
import {
    ObservableAuthApi,
    ObservableCategoryApi,
    ObservableExpenseApi,
    ObservableIncomeApi,
    ObservableUserApi
} from './ObservableAPI';

import {AuthApiRequestFactory, AuthApiResponseProcessor} from "../apis/AuthApi";

import {CategoryApiRequestFactory, CategoryApiResponseProcessor} from "../apis/CategoryApi";

import {ExpenseApiRequestFactory, ExpenseApiResponseProcessor} from "../apis/ExpenseApi";

import {IncomeApiRequestFactory, IncomeApiResponseProcessor} from "../apis/IncomeApi";

import {UserApiRequestFactory, UserApiResponseProcessor} from "../apis/UserApi";

export class PromiseAuthApi {
    private api: ObservableAuthApi

    public constructor(
        configuration: Configuration,
        requestFactory?: AuthApiRequestFactory,
        responseProcessor?: AuthApiResponseProcessor
    ) {
        this.api = new ObservableAuthApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param loginDto
     */
    public apiAuthLoginPostWithHttpInfo(loginDto?: LoginDto, _options?: Configuration): Promise<HttpInfo<void>> {
        const result = this.api.apiAuthLoginPostWithHttpInfo(loginDto, _options);
        return result.toPromise();
    }

    /**
     * @param loginDto
     */
    public apiAuthLoginPost(loginDto?: LoginDto, _options?: Configuration): Promise<void> {
        const result = this.api.apiAuthLoginPost(loginDto, _options);
        return result.toPromise();
    }

    /**
     * @param registrationDto
     */
    public apiAuthRegisterPostWithHttpInfo(registrationDto?: RegistrationDto, _options?: Configuration): Promise<HttpInfo<RegistrationSuccessDto>> {
        const result = this.api.apiAuthRegisterPostWithHttpInfo(registrationDto, _options);
        return result.toPromise();
    }

    /**
     * @param registrationDto
     */
    public apiAuthRegisterPost(registrationDto?: RegistrationDto, _options?: Configuration): Promise<RegistrationSuccessDto> {
        const result = this.api.apiAuthRegisterPost(registrationDto, _options);
        return result.toPromise();
    }


}


export class PromiseCategoryApi {
    private api: ObservableCategoryApi

    public constructor(
        configuration: Configuration,
        requestFactory?: CategoryApiRequestFactory,
        responseProcessor?: CategoryApiResponseProcessor
    ) {
        this.api = new ObservableCategoryApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param categoryDto
     */
    public apiCategoryAddOrUpdatePostWithHttpInfo(categoryDto?: CategoryDto, _options?: Configuration): Promise<HttpInfo<CategoryDto>> {
        const result = this.api.apiCategoryAddOrUpdatePostWithHttpInfo(categoryDto, _options);
        return result.toPromise();
    }

    /**
     * @param categoryDto
     */
    public apiCategoryAddOrUpdatePost(categoryDto?: CategoryDto, _options?: Configuration): Promise<CategoryDto> {
        const result = this.api.apiCategoryAddOrUpdatePost(categoryDto, _options);
        return result.toPromise();
    }

    /**
     * @param categoryId
     */
    public apiCategoryDeleteWithHttpInfo(categoryId?: number, _options?: Configuration): Promise<HttpInfo<boolean>> {
        const result = this.api.apiCategoryDeleteWithHttpInfo(categoryId, _options);
        return result.toPromise();
    }

    /**
     * @param categoryId
     */
    public apiCategoryDelete(categoryId?: number, _options?: Configuration): Promise<boolean> {
        const result = this.api.apiCategoryDelete(categoryId, _options);
        return result.toPromise();
    }

    /**
     * @param id
     */
    public apiCategoryGetWithHttpInfo(id?: number, _options?: Configuration): Promise<HttpInfo<CategoryDto>> {
        const result = this.api.apiCategoryGetWithHttpInfo(id, _options);
        return result.toPromise();
    }

    /**
     * @param id
     */
    public apiCategoryGet(id?: number, _options?: Configuration): Promise<CategoryDto> {
        const result = this.api.apiCategoryGet(id, _options);
        return result.toPromise();
    }

    /**
     */
    public apiCategoryGetAllGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<Array<CategoryDto>>> {
        const result = this.api.apiCategoryGetAllGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiCategoryGetAllGet(_options?: Configuration): Promise<Array<CategoryDto>> {
        const result = this.api.apiCategoryGetAllGet(_options);
        return result.toPromise();
    }


}


export class PromiseExpenseApi {
    private api: ObservableExpenseApi

    public constructor(
        configuration: Configuration,
        requestFactory?: ExpenseApiRequestFactory,
        responseProcessor?: ExpenseApiResponseProcessor
    ) {
        this.api = new ObservableExpenseApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param expenseDto
     */
    public apiExpenseAddOrUpdatePostWithHttpInfo(expenseDto?: ExpenseDto, _options?: Configuration): Promise<HttpInfo<ExpenseDto>> {
        const result = this.api.apiExpenseAddOrUpdatePostWithHttpInfo(expenseDto, _options);
        return result.toPromise();
    }

    /**
     * @param expenseDto
     */
    public apiExpenseAddOrUpdatePost(expenseDto?: ExpenseDto, _options?: Configuration): Promise<ExpenseDto> {
        const result = this.api.apiExpenseAddOrUpdatePost(expenseDto, _options);
        return result.toPromise();
    }

    /**
     * @param expenseId
     */
    public apiExpenseDeleteWithHttpInfo(expenseId?: number, _options?: Configuration): Promise<HttpInfo<boolean>> {
        const result = this.api.apiExpenseDeleteWithHttpInfo(expenseId, _options);
        return result.toPromise();
    }

    /**
     * @param expenseId
     */
    public apiExpenseDelete(expenseId?: number, _options?: Configuration): Promise<boolean> {
        const result = this.api.apiExpenseDelete(expenseId, _options);
        return result.toPromise();
    }

    /**
     * @param id
     */
    public apiExpenseGetWithHttpInfo(id?: number, _options?: Configuration): Promise<HttpInfo<ExpenseDto>> {
        const result = this.api.apiExpenseGetWithHttpInfo(id, _options);
        return result.toPromise();
    }

    /**
     * @param id
     */
    public apiExpenseGet(id?: number, _options?: Configuration): Promise<ExpenseDto> {
        const result = this.api.apiExpenseGet(id, _options);
        return result.toPromise();
    }

    /**
     */
    public apiExpenseGetAllGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<Array<ExpenseDto>>> {
        const result = this.api.apiExpenseGetAllGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiExpenseGetAllGet(_options?: Configuration): Promise<Array<ExpenseDto>> {
        const result = this.api.apiExpenseGetAllGet(_options);
        return result.toPromise();
    }

    /**
     * @param minAmount
     * @param maxAmount
     */
    public apiExpenseGetByAmountRangeGetWithHttpInfo(minAmount?: number, maxAmount?: number, _options?: Configuration): Promise<HttpInfo<Array<ExpenseDto>>> {
        const result = this.api.apiExpenseGetByAmountRangeGetWithHttpInfo(minAmount, maxAmount, _options);
        return result.toPromise();
    }

    /**
     * @param minAmount
     * @param maxAmount
     */
    public apiExpenseGetByAmountRangeGet(minAmount?: number, maxAmount?: number, _options?: Configuration): Promise<Array<ExpenseDto>> {
        const result = this.api.apiExpenseGetByAmountRangeGet(minAmount, maxAmount, _options);
        return result.toPromise();
    }

    /**
     * @param categoryId
     */
    public apiExpenseGetByCategoryGetWithHttpInfo(categoryId?: number, _options?: Configuration): Promise<HttpInfo<Array<ExpenseDto>>> {
        const result = this.api.apiExpenseGetByCategoryGetWithHttpInfo(categoryId, _options);
        return result.toPromise();
    }

    /**
     * @param categoryId
     */
    public apiExpenseGetByCategoryGet(categoryId?: number, _options?: Configuration): Promise<Array<ExpenseDto>> {
        const result = this.api.apiExpenseGetByCategoryGet(categoryId, _options);
        return result.toPromise();
    }

    /**
     * @param startDate
     * @param endDate
     */
    public apiExpenseGetByDateRangeGetWithHttpInfo(startDate?: Date, endDate?: Date, _options?: Configuration): Promise<HttpInfo<Array<ExpenseDto>>> {
        const result = this.api.apiExpenseGetByDateRangeGetWithHttpInfo(startDate, endDate, _options);
        return result.toPromise();
    }

    /**
     * @param startDate
     * @param endDate
     */
    public apiExpenseGetByDateRangeGet(startDate?: Date, endDate?: Date, _options?: Configuration): Promise<Array<ExpenseDto>> {
        const result = this.api.apiExpenseGetByDateRangeGet(startDate, endDate, _options);
        return result.toPromise();
    }


}


export class PromiseIncomeApi {
    private api: ObservableIncomeApi

    public constructor(
        configuration: Configuration,
        requestFactory?: IncomeApiRequestFactory,
        responseProcessor?: IncomeApiResponseProcessor
    ) {
        this.api = new ObservableIncomeApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param incomeDto
     */
    public apiIncomeAddOrUpdatePostWithHttpInfo(incomeDto?: IncomeDto, _options?: Configuration): Promise<HttpInfo<IncomeDto>> {
        const result = this.api.apiIncomeAddOrUpdatePostWithHttpInfo(incomeDto, _options);
        return result.toPromise();
    }

    /**
     * @param incomeDto
     */
    public apiIncomeAddOrUpdatePost(incomeDto?: IncomeDto, _options?: Configuration): Promise<IncomeDto> {
        const result = this.api.apiIncomeAddOrUpdatePost(incomeDto, _options);
        return result.toPromise();
    }

    /**
     * @param incomeId
     */
    public apiIncomeDeleteWithHttpInfo(incomeId?: number, _options?: Configuration): Promise<HttpInfo<boolean>> {
        const result = this.api.apiIncomeDeleteWithHttpInfo(incomeId, _options);
        return result.toPromise();
    }

    /**
     * @param incomeId
     */
    public apiIncomeDelete(incomeId?: number, _options?: Configuration): Promise<boolean> {
        const result = this.api.apiIncomeDelete(incomeId, _options);
        return result.toPromise();
    }

    /**
     */
    public apiIncomeDeleteAllDeleteWithHttpInfo(_options?: Configuration): Promise<HttpInfo<boolean>> {
        const result = this.api.apiIncomeDeleteAllDeleteWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiIncomeDeleteAllDelete(_options?: Configuration): Promise<boolean> {
        const result = this.api.apiIncomeDeleteAllDelete(_options);
        return result.toPromise();
    }

    /**
     * @param id
     */
    public apiIncomeGetWithHttpInfo(id?: number, _options?: Configuration): Promise<HttpInfo<IncomeDto>> {
        const result = this.api.apiIncomeGetWithHttpInfo(id, _options);
        return result.toPromise();
    }

    /**
     * @param id
     */
    public apiIncomeGet(id?: number, _options?: Configuration): Promise<IncomeDto> {
        const result = this.api.apiIncomeGet(id, _options);
        return result.toPromise();
    }

    /**
     */
    public apiIncomeGetAllGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<Array<IncomeDto>>> {
        const result = this.api.apiIncomeGetAllGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiIncomeGetAllGet(_options?: Configuration): Promise<Array<IncomeDto>> {
        const result = this.api.apiIncomeGetAllGet(_options);
        return result.toPromise();
    }


}


export class PromiseUserApi {
    private api: ObservableUserApi

    public constructor(
        configuration: Configuration,
        requestFactory?: UserApiRequestFactory,
        responseProcessor?: UserApiResponseProcessor
    ) {
        this.api = new ObservableUserApi(configuration, requestFactory, responseProcessor);
    }

    /**
     */
    public apiUserBalanceGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<number>> {
        const result = this.api.apiUserBalanceGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserBalanceGet(_options?: Configuration): Promise<number> {
        const result = this.api.apiUserBalanceGet(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserDeleteAllDeleteWithHttpInfo(_options?: Configuration): Promise<HttpInfo<boolean>> {
        const result = this.api.apiUserDeleteAllDeleteWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserDeleteAllDelete(_options?: Configuration): Promise<boolean> {
        const result = this.api.apiUserDeleteAllDelete(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserExportDataGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<UserTransactionsDto>> {
        const result = this.api.apiUserExportDataGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserExportDataGet(_options?: Configuration): Promise<UserTransactionsDto> {
        const result = this.api.apiUserExportDataGet(_options);
        return result.toPromise();
    }

    /**
     * @param categories
     * @param dateFrom
     * @param dateTo
     */
    public apiUserFilteredTransactionsGetWithHttpInfo(categories?: Array<number>, dateFrom?: Date, dateTo?: Date, _options?: Configuration): Promise<HttpInfo<UserTransactionsDto>> {
        const result = this.api.apiUserFilteredTransactionsGetWithHttpInfo(categories, dateFrom, dateTo, _options);
        return result.toPromise();
    }

    /**
     * @param categories
     * @param dateFrom
     * @param dateTo
     */
    public apiUserFilteredTransactionsGet(categories?: Array<number>, dateFrom?: Date, dateTo?: Date, _options?: Configuration): Promise<UserTransactionsDto> {
        const result = this.api.apiUserFilteredTransactionsGet(categories, dateFrom, dateTo, _options);
        return result.toPromise();
    }

    /**
     */
    public apiUserGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<UserDto>> {
        const result = this.api.apiUserGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserGet(_options?: Configuration): Promise<UserDto> {
        const result = this.api.apiUserGet(_options);
        return result.toPromise();
    }

    /**
     * @param userTransactionsDto
     */
    public apiUserImportDataPostWithHttpInfo(userTransactionsDto?: UserTransactionsDto, _options?: Configuration): Promise<HttpInfo<boolean>> {
        const result = this.api.apiUserImportDataPostWithHttpInfo(userTransactionsDto, _options);
        return result.toPromise();
    }

    /**
     * @param userTransactionsDto
     */
    public apiUserImportDataPost(userTransactionsDto?: UserTransactionsDto, _options?: Configuration): Promise<boolean> {
        const result = this.api.apiUserImportDataPost(userTransactionsDto, _options);
        return result.toPromise();
    }

    /**
     */
    public apiUserStatisticsGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<UserStatisticsDto>> {
        const result = this.api.apiUserStatisticsGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserStatisticsGet(_options?: Configuration): Promise<UserStatisticsDto> {
        const result = this.api.apiUserStatisticsGet(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserStatsGraphGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<MemoryStream>> {
        const result = this.api.apiUserStatsGraphGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserStatsGraphGet(_options?: Configuration): Promise<MemoryStream> {
        const result = this.api.apiUserStatsGraphGet(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserTotalExpenseGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<number>> {
        const result = this.api.apiUserTotalExpenseGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserTotalExpenseGet(_options?: Configuration): Promise<number> {
        const result = this.api.apiUserTotalExpenseGet(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserTotalIncomeGetWithHttpInfo(_options?: Configuration): Promise<HttpInfo<number>> {
        const result = this.api.apiUserTotalIncomeGetWithHttpInfo(_options);
        return result.toPromise();
    }

    /**
     */
    public apiUserTotalIncomeGet(_options?: Configuration): Promise<number> {
        const result = this.api.apiUserTotalIncomeGet(_options);
        return result.toPromise();
    }


}



