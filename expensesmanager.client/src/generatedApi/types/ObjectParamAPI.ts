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
} from "./ObservableAPI";
import {AuthApiRequestFactory, AuthApiResponseProcessor} from "../apis/AuthApi";
import {CategoryApiRequestFactory, CategoryApiResponseProcessor} from "../apis/CategoryApi";
import {ExpenseApiRequestFactory, ExpenseApiResponseProcessor} from "../apis/ExpenseApi";
import {IncomeApiRequestFactory, IncomeApiResponseProcessor} from "../apis/IncomeApi";
import {UserApiRequestFactory, UserApiResponseProcessor} from "../apis/UserApi";

export interface AuthApiApiAuthLoginPostRequest {
    /**
     *
     * @type LoginDto
     * @memberof AuthApiapiAuthLoginPost
     */
    loginDto?: LoginDto
}

export interface AuthApiApiAuthRegisterPostRequest {
    /**
     *
     * @type RegistrationDto
     * @memberof AuthApiapiAuthRegisterPost
     */
    registrationDto?: RegistrationDto
}

export class ObjectAuthApi {
    private api: ObservableAuthApi

    public constructor(configuration: Configuration, requestFactory?: AuthApiRequestFactory, responseProcessor?: AuthApiResponseProcessor) {
        this.api = new ObservableAuthApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param param the request object
     */
    public apiAuthLoginPostWithHttpInfo(param: AuthApiApiAuthLoginPostRequest = {}, options?: Configuration): Promise<HttpInfo<void>> {
        return this.api.apiAuthLoginPostWithHttpInfo(param.loginDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiAuthLoginPost(param: AuthApiApiAuthLoginPostRequest = {}, options?: Configuration): Promise<void> {
        return this.api.apiAuthLoginPost(param.loginDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiAuthRegisterPostWithHttpInfo(param: AuthApiApiAuthRegisterPostRequest = {}, options?: Configuration): Promise<HttpInfo<RegistrationSuccessDto>> {
        return this.api.apiAuthRegisterPostWithHttpInfo(param.registrationDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiAuthRegisterPost(param: AuthApiApiAuthRegisterPostRequest = {}, options?: Configuration): Promise<RegistrationSuccessDto> {
        return this.api.apiAuthRegisterPost(param.registrationDto, options).toPromise();
    }

}

export interface CategoryApiApiCategoryAddOrUpdatePostRequest {
    /**
     *
     * @type CategoryDto
     * @memberof CategoryApiapiCategoryAddOrUpdatePost
     */
    categoryDto?: CategoryDto
}

export interface CategoryApiApiCategoryDeleteRequest {
    /**
     *
     * @type number
     * @memberof CategoryApiapiCategoryDelete
     */
    categoryId?: number
}

export interface CategoryApiApiCategoryGetRequest {
    /**
     *
     * @type number
     * @memberof CategoryApiapiCategoryGet
     */
    id?: number
}

export interface CategoryApiApiCategoryGetAllGetRequest {
}

export class ObjectCategoryApi {
    private api: ObservableCategoryApi

    public constructor(configuration: Configuration, requestFactory?: CategoryApiRequestFactory, responseProcessor?: CategoryApiResponseProcessor) {
        this.api = new ObservableCategoryApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param param the request object
     */
    public apiCategoryAddOrUpdatePostWithHttpInfo(param: CategoryApiApiCategoryAddOrUpdatePostRequest = {}, options?: Configuration): Promise<HttpInfo<CategoryDto>> {
        return this.api.apiCategoryAddOrUpdatePostWithHttpInfo(param.categoryDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiCategoryAddOrUpdatePost(param: CategoryApiApiCategoryAddOrUpdatePostRequest = {}, options?: Configuration): Promise<CategoryDto> {
        return this.api.apiCategoryAddOrUpdatePost(param.categoryDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiCategoryDeleteWithHttpInfo(param: CategoryApiApiCategoryDeleteRequest = {}, options?: Configuration): Promise<HttpInfo<boolean>> {
        return this.api.apiCategoryDeleteWithHttpInfo(param.categoryId, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiCategoryDelete(param: CategoryApiApiCategoryDeleteRequest = {}, options?: Configuration): Promise<boolean> {
        return this.api.apiCategoryDelete(param.categoryId, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiCategoryGetWithHttpInfo(param: CategoryApiApiCategoryGetRequest = {}, options?: Configuration): Promise<HttpInfo<CategoryDto>> {
        return this.api.apiCategoryGetWithHttpInfo(param.id, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiCategoryGet(param: CategoryApiApiCategoryGetRequest = {}, options?: Configuration): Promise<CategoryDto> {
        return this.api.apiCategoryGet(param.id, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiCategoryGetAllGetWithHttpInfo(param: CategoryApiApiCategoryGetAllGetRequest = {}, options?: Configuration): Promise<HttpInfo<Array<CategoryDto>>> {
        return this.api.apiCategoryGetAllGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiCategoryGetAllGet(param: CategoryApiApiCategoryGetAllGetRequest = {}, options?: Configuration): Promise<Array<CategoryDto>> {
        return this.api.apiCategoryGetAllGet(options).toPromise();
    }

}

export interface ExpenseApiApiExpenseAddOrUpdatePostRequest {
    /**
     *
     * @type ExpenseDto
     * @memberof ExpenseApiapiExpenseAddOrUpdatePost
     */
    expenseDto?: ExpenseDto
}

export interface ExpenseApiApiExpenseDeleteRequest {
    /**
     *
     * @type number
     * @memberof ExpenseApiapiExpenseDelete
     */
    expenseId?: number
}

export interface ExpenseApiApiExpenseGetRequest {
    /**
     *
     * @type number
     * @memberof ExpenseApiapiExpenseGet
     */
    id?: number
}

export interface ExpenseApiApiExpenseGetAllGetRequest {
}

export interface ExpenseApiApiExpenseGetByAmountRangeGetRequest {
    /**
     *
     * @type number
     * @memberof ExpenseApiapiExpenseGetByAmountRangeGet
     */
    minAmount?: number
    /**
     *
     * @type number
     * @memberof ExpenseApiapiExpenseGetByAmountRangeGet
     */
    maxAmount?: number
}

export interface ExpenseApiApiExpenseGetByCategoryGetRequest {
    /**
     *
     * @type number
     * @memberof ExpenseApiapiExpenseGetByCategoryGet
     */
    categoryId?: number
}

export interface ExpenseApiApiExpenseGetByDateRangeGetRequest {
    /**
     *
     * @type Date
     * @memberof ExpenseApiapiExpenseGetByDateRangeGet
     */
    startDate?: Date
    /**
     *
     * @type Date
     * @memberof ExpenseApiapiExpenseGetByDateRangeGet
     */
    endDate?: Date
}

export class ObjectExpenseApi {
    private api: ObservableExpenseApi

    public constructor(configuration: Configuration, requestFactory?: ExpenseApiRequestFactory, responseProcessor?: ExpenseApiResponseProcessor) {
        this.api = new ObservableExpenseApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param param the request object
     */
    public apiExpenseAddOrUpdatePostWithHttpInfo(param: ExpenseApiApiExpenseAddOrUpdatePostRequest = {}, options?: Configuration): Promise<HttpInfo<ExpenseDto>> {
        return this.api.apiExpenseAddOrUpdatePostWithHttpInfo(param.expenseDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseAddOrUpdatePost(param: ExpenseApiApiExpenseAddOrUpdatePostRequest = {}, options?: Configuration): Promise<ExpenseDto> {
        return this.api.apiExpenseAddOrUpdatePost(param.expenseDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseDeleteWithHttpInfo(param: ExpenseApiApiExpenseDeleteRequest = {}, options?: Configuration): Promise<HttpInfo<boolean>> {
        return this.api.apiExpenseDeleteWithHttpInfo(param.expenseId, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseDelete(param: ExpenseApiApiExpenseDeleteRequest = {}, options?: Configuration): Promise<boolean> {
        return this.api.apiExpenseDelete(param.expenseId, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetWithHttpInfo(param: ExpenseApiApiExpenseGetRequest = {}, options?: Configuration): Promise<HttpInfo<ExpenseDto>> {
        return this.api.apiExpenseGetWithHttpInfo(param.id, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGet(param: ExpenseApiApiExpenseGetRequest = {}, options?: Configuration): Promise<ExpenseDto> {
        return this.api.apiExpenseGet(param.id, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetAllGetWithHttpInfo(param: ExpenseApiApiExpenseGetAllGetRequest = {}, options?: Configuration): Promise<HttpInfo<Array<ExpenseDto>>> {
        return this.api.apiExpenseGetAllGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetAllGet(param: ExpenseApiApiExpenseGetAllGetRequest = {}, options?: Configuration): Promise<Array<ExpenseDto>> {
        return this.api.apiExpenseGetAllGet(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetByAmountRangeGetWithHttpInfo(param: ExpenseApiApiExpenseGetByAmountRangeGetRequest = {}, options?: Configuration): Promise<HttpInfo<Array<ExpenseDto>>> {
        return this.api.apiExpenseGetByAmountRangeGetWithHttpInfo(param.minAmount, param.maxAmount, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetByAmountRangeGet(param: ExpenseApiApiExpenseGetByAmountRangeGetRequest = {}, options?: Configuration): Promise<Array<ExpenseDto>> {
        return this.api.apiExpenseGetByAmountRangeGet(param.minAmount, param.maxAmount, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetByCategoryGetWithHttpInfo(param: ExpenseApiApiExpenseGetByCategoryGetRequest = {}, options?: Configuration): Promise<HttpInfo<Array<ExpenseDto>>> {
        return this.api.apiExpenseGetByCategoryGetWithHttpInfo(param.categoryId, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetByCategoryGet(param: ExpenseApiApiExpenseGetByCategoryGetRequest = {}, options?: Configuration): Promise<Array<ExpenseDto>> {
        return this.api.apiExpenseGetByCategoryGet(param.categoryId, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetByDateRangeGetWithHttpInfo(param: ExpenseApiApiExpenseGetByDateRangeGetRequest = {}, options?: Configuration): Promise<HttpInfo<Array<ExpenseDto>>> {
        return this.api.apiExpenseGetByDateRangeGetWithHttpInfo(param.startDate, param.endDate, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiExpenseGetByDateRangeGet(param: ExpenseApiApiExpenseGetByDateRangeGetRequest = {}, options?: Configuration): Promise<Array<ExpenseDto>> {
        return this.api.apiExpenseGetByDateRangeGet(param.startDate, param.endDate, options).toPromise();
    }

}

export interface IncomeApiApiIncomeAddOrUpdatePostRequest {
    /**
     *
     * @type IncomeDto
     * @memberof IncomeApiapiIncomeAddOrUpdatePost
     */
    incomeDto?: IncomeDto
}

export interface IncomeApiApiIncomeDeleteRequest {
    /**
     *
     * @type number
     * @memberof IncomeApiapiIncomeDelete
     */
    incomeId?: number
}

export interface IncomeApiApiIncomeDeleteAllDeleteRequest {
}

export interface IncomeApiApiIncomeGetRequest {
    /**
     *
     * @type number
     * @memberof IncomeApiapiIncomeGet
     */
    id?: number
}

export interface IncomeApiApiIncomeGetAllGetRequest {
}

export class ObjectIncomeApi {
    private api: ObservableIncomeApi

    public constructor(configuration: Configuration, requestFactory?: IncomeApiRequestFactory, responseProcessor?: IncomeApiResponseProcessor) {
        this.api = new ObservableIncomeApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param param the request object
     */
    public apiIncomeAddOrUpdatePostWithHttpInfo(param: IncomeApiApiIncomeAddOrUpdatePostRequest = {}, options?: Configuration): Promise<HttpInfo<IncomeDto>> {
        return this.api.apiIncomeAddOrUpdatePostWithHttpInfo(param.incomeDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeAddOrUpdatePost(param: IncomeApiApiIncomeAddOrUpdatePostRequest = {}, options?: Configuration): Promise<IncomeDto> {
        return this.api.apiIncomeAddOrUpdatePost(param.incomeDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeDeleteWithHttpInfo(param: IncomeApiApiIncomeDeleteRequest = {}, options?: Configuration): Promise<HttpInfo<boolean>> {
        return this.api.apiIncomeDeleteWithHttpInfo(param.incomeId, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeDelete(param: IncomeApiApiIncomeDeleteRequest = {}, options?: Configuration): Promise<boolean> {
        return this.api.apiIncomeDelete(param.incomeId, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeDeleteAllDeleteWithHttpInfo(param: IncomeApiApiIncomeDeleteAllDeleteRequest = {}, options?: Configuration): Promise<HttpInfo<boolean>> {
        return this.api.apiIncomeDeleteAllDeleteWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeDeleteAllDelete(param: IncomeApiApiIncomeDeleteAllDeleteRequest = {}, options?: Configuration): Promise<boolean> {
        return this.api.apiIncomeDeleteAllDelete(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeGetWithHttpInfo(param: IncomeApiApiIncomeGetRequest = {}, options?: Configuration): Promise<HttpInfo<IncomeDto>> {
        return this.api.apiIncomeGetWithHttpInfo(param.id, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeGet(param: IncomeApiApiIncomeGetRequest = {}, options?: Configuration): Promise<IncomeDto> {
        return this.api.apiIncomeGet(param.id, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeGetAllGetWithHttpInfo(param: IncomeApiApiIncomeGetAllGetRequest = {}, options?: Configuration): Promise<HttpInfo<Array<IncomeDto>>> {
        return this.api.apiIncomeGetAllGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiIncomeGetAllGet(param: IncomeApiApiIncomeGetAllGetRequest = {}, options?: Configuration): Promise<Array<IncomeDto>> {
        return this.api.apiIncomeGetAllGet(options).toPromise();
    }

}

export interface UserApiApiUserBalanceGetRequest {
}

export interface UserApiApiUserDeleteAllDeleteRequest {
}

export interface UserApiApiUserExportDataGetRequest {
}

export interface UserApiApiUserFilteredTransactionsGetRequest {
    /**
     *
     * @type Array&lt;number&gt;
     * @memberof UserApiapiUserFilteredTransactionsGet
     */
    categories?: Array<number>
    /**
     *
     * @type Date
     * @memberof UserApiapiUserFilteredTransactionsGet
     */
    dateFrom?: Date
    /**
     *
     * @type Date
     * @memberof UserApiapiUserFilteredTransactionsGet
     */
    dateTo?: Date
}

export interface UserApiApiUserGetRequest {
}

export interface UserApiApiUserImportDataPostRequest {
    /**
     *
     * @type UserTransactionsDto
     * @memberof UserApiapiUserImportDataPost
     */
    userTransactionsDto?: UserTransactionsDto
}

export interface UserApiApiUserStatisticsGetRequest {
}

export interface UserApiApiUserStatsGraphGetRequest {
}

export interface UserApiApiUserTotalExpenseGetRequest {
}

export interface UserApiApiUserTotalIncomeGetRequest {
}

export class ObjectUserApi {
    private api: ObservableUserApi

    public constructor(configuration: Configuration, requestFactory?: UserApiRequestFactory, responseProcessor?: UserApiResponseProcessor) {
        this.api = new ObservableUserApi(configuration, requestFactory, responseProcessor);
    }

    /**
     * @param param the request object
     */
    public apiUserBalanceGetWithHttpInfo(param: UserApiApiUserBalanceGetRequest = {}, options?: Configuration): Promise<HttpInfo<number>> {
        return this.api.apiUserBalanceGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserBalanceGet(param: UserApiApiUserBalanceGetRequest = {}, options?: Configuration): Promise<number> {
        return this.api.apiUserBalanceGet(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserDeleteAllDeleteWithHttpInfo(param: UserApiApiUserDeleteAllDeleteRequest = {}, options?: Configuration): Promise<HttpInfo<boolean>> {
        return this.api.apiUserDeleteAllDeleteWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserDeleteAllDelete(param: UserApiApiUserDeleteAllDeleteRequest = {}, options?: Configuration): Promise<boolean> {
        return this.api.apiUserDeleteAllDelete(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserExportDataGetWithHttpInfo(param: UserApiApiUserExportDataGetRequest = {}, options?: Configuration): Promise<HttpInfo<UserTransactionsDto>> {
        return this.api.apiUserExportDataGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserExportDataGet(param: UserApiApiUserExportDataGetRequest = {}, options?: Configuration): Promise<UserTransactionsDto> {
        return this.api.apiUserExportDataGet(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserFilteredTransactionsGetWithHttpInfo(param: UserApiApiUserFilteredTransactionsGetRequest = {}, options?: Configuration): Promise<HttpInfo<UserTransactionsDto>> {
        return this.api.apiUserFilteredTransactionsGetWithHttpInfo(param.categories, param.dateFrom, param.dateTo, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserFilteredTransactionsGet(param: UserApiApiUserFilteredTransactionsGetRequest = {}, options?: Configuration): Promise<UserTransactionsDto> {
        return this.api.apiUserFilteredTransactionsGet(param.categories, param.dateFrom, param.dateTo, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserGetWithHttpInfo(param: UserApiApiUserGetRequest = {}, options?: Configuration): Promise<HttpInfo<UserDto>> {
        return this.api.apiUserGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserGet(param: UserApiApiUserGetRequest = {}, options?: Configuration): Promise<UserDto> {
        return this.api.apiUserGet(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserImportDataPostWithHttpInfo(param: UserApiApiUserImportDataPostRequest = {}, options?: Configuration): Promise<HttpInfo<boolean>> {
        return this.api.apiUserImportDataPostWithHttpInfo(param.userTransactionsDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserImportDataPost(param: UserApiApiUserImportDataPostRequest = {}, options?: Configuration): Promise<boolean> {
        return this.api.apiUserImportDataPost(param.userTransactionsDto, options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserStatisticsGetWithHttpInfo(param: UserApiApiUserStatisticsGetRequest = {}, options?: Configuration): Promise<HttpInfo<UserStatisticsDto>> {
        return this.api.apiUserStatisticsGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserStatisticsGet(param: UserApiApiUserStatisticsGetRequest = {}, options?: Configuration): Promise<UserStatisticsDto> {
        return this.api.apiUserStatisticsGet(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserStatsGraphGetWithHttpInfo(param: UserApiApiUserStatsGraphGetRequest = {}, options?: Configuration): Promise<HttpInfo<MemoryStream>> {
        return this.api.apiUserStatsGraphGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserStatsGraphGet(param: UserApiApiUserStatsGraphGetRequest = {}, options?: Configuration): Promise<MemoryStream> {
        return this.api.apiUserStatsGraphGet(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserTotalExpenseGetWithHttpInfo(param: UserApiApiUserTotalExpenseGetRequest = {}, options?: Configuration): Promise<HttpInfo<number>> {
        return this.api.apiUserTotalExpenseGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserTotalExpenseGet(param: UserApiApiUserTotalExpenseGetRequest = {}, options?: Configuration): Promise<number> {
        return this.api.apiUserTotalExpenseGet(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserTotalIncomeGetWithHttpInfo(param: UserApiApiUserTotalIncomeGetRequest = {}, options?: Configuration): Promise<HttpInfo<number>> {
        return this.api.apiUserTotalIncomeGetWithHttpInfo(options).toPromise();
    }

    /**
     * @param param the request object
     */
    public apiUserTotalIncomeGet(param: UserApiApiUserTotalIncomeGetRequest = {}, options?: Configuration): Promise<number> {
        return this.api.apiUserTotalIncomeGet(options).toPromise();
    }

}
