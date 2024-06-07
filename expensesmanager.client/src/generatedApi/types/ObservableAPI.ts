import {HttpInfo, RequestContext, ResponseContext} from '../http/http';
import {Configuration} from '../configuration'
import {from, map, mergeMap, Observable, of} from '../rxjsStub';
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

import {AuthApiRequestFactory, AuthApiResponseProcessor} from "../apis/AuthApi";
import {CategoryApiRequestFactory, CategoryApiResponseProcessor} from "../apis/CategoryApi";
import {ExpenseApiRequestFactory, ExpenseApiResponseProcessor} from "../apis/ExpenseApi";
import {IncomeApiRequestFactory, IncomeApiResponseProcessor} from "../apis/IncomeApi";
import {UserApiRequestFactory, UserApiResponseProcessor} from "../apis/UserApi";

export class ObservableAuthApi {
    private requestFactory: AuthApiRequestFactory;
    private responseProcessor: AuthApiResponseProcessor;
    private configuration: Configuration;

    public constructor(
        configuration: Configuration,
        requestFactory?: AuthApiRequestFactory,
        responseProcessor?: AuthApiResponseProcessor
    ) {
        this.configuration = configuration;
        this.requestFactory = requestFactory || new AuthApiRequestFactory(configuration);
        this.responseProcessor = responseProcessor || new AuthApiResponseProcessor();
    }

    /**
     * @param loginDto
     */
    public apiAuthLoginPostWithHttpInfo(loginDto?: LoginDto, _options?: Configuration): Observable<HttpInfo<void>> {
        const requestContextPromise = this.requestFactory.apiAuthLoginPost(loginDto, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiAuthLoginPostWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param loginDto
     */
    public apiAuthLoginPost(loginDto?: LoginDto, _options?: Configuration): Observable<void> {
        return this.apiAuthLoginPostWithHttpInfo(loginDto, _options).pipe(map((apiResponse: HttpInfo<void>) => apiResponse.data));
    }

    /**
     * @param registrationDto
     */
    public apiAuthRegisterPostWithHttpInfo(registrationDto?: RegistrationDto, _options?: Configuration): Observable<HttpInfo<RegistrationSuccessDto>> {
        const requestContextPromise = this.requestFactory.apiAuthRegisterPost(registrationDto, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiAuthRegisterPostWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param registrationDto
     */
    public apiAuthRegisterPost(registrationDto?: RegistrationDto, _options?: Configuration): Observable<RegistrationSuccessDto> {
        return this.apiAuthRegisterPostWithHttpInfo(registrationDto, _options).pipe(map((apiResponse: HttpInfo<RegistrationSuccessDto>) => apiResponse.data));
    }

}

export class ObservableCategoryApi {
    private requestFactory: CategoryApiRequestFactory;
    private responseProcessor: CategoryApiResponseProcessor;
    private configuration: Configuration;

    public constructor(
        configuration: Configuration,
        requestFactory?: CategoryApiRequestFactory,
        responseProcessor?: CategoryApiResponseProcessor
    ) {
        this.configuration = configuration;
        this.requestFactory = requestFactory || new CategoryApiRequestFactory(configuration);
        this.responseProcessor = responseProcessor || new CategoryApiResponseProcessor();
    }

    /**
     * @param categoryDto
     */
    public apiCategoryAddOrUpdatePostWithHttpInfo(categoryDto?: CategoryDto, _options?: Configuration): Observable<HttpInfo<CategoryDto>> {
        const requestContextPromise = this.requestFactory.apiCategoryAddOrUpdatePost(categoryDto, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiCategoryAddOrUpdatePostWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param categoryDto
     */
    public apiCategoryAddOrUpdatePost(categoryDto?: CategoryDto, _options?: Configuration): Observable<CategoryDto> {
        return this.apiCategoryAddOrUpdatePostWithHttpInfo(categoryDto, _options).pipe(map((apiResponse: HttpInfo<CategoryDto>) => apiResponse.data));
    }

    /**
     * @param categoryId
     */
    public apiCategoryDeleteWithHttpInfo(categoryId?: number, _options?: Configuration): Observable<HttpInfo<boolean>> {
        const requestContextPromise = this.requestFactory.apiCategoryDelete(categoryId, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiCategoryDeleteWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param categoryId
     */
    public apiCategoryDelete(categoryId?: number, _options?: Configuration): Observable<boolean> {
        return this.apiCategoryDeleteWithHttpInfo(categoryId, _options).pipe(map((apiResponse: HttpInfo<boolean>) => apiResponse.data));
    }

    /**
     * @param id
     */
    public apiCategoryGetWithHttpInfo(id?: number, _options?: Configuration): Observable<HttpInfo<CategoryDto>> {
        const requestContextPromise = this.requestFactory.apiCategoryGet(id, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiCategoryGetWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param id
     */
    public apiCategoryGet(id?: number, _options?: Configuration): Observable<CategoryDto> {
        return this.apiCategoryGetWithHttpInfo(id, _options).pipe(map((apiResponse: HttpInfo<CategoryDto>) => apiResponse.data));
    }

    /**
     */
    public apiCategoryGetAllGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<Array<CategoryDto>>> {
        const requestContextPromise = this.requestFactory.apiCategoryGetAllGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiCategoryGetAllGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiCategoryGetAllGet(_options?: Configuration): Observable<Array<CategoryDto>> {
        return this.apiCategoryGetAllGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<Array<CategoryDto>>) => apiResponse.data));
    }

}

export class ObservableExpenseApi {
    private requestFactory: ExpenseApiRequestFactory;
    private responseProcessor: ExpenseApiResponseProcessor;
    private configuration: Configuration;

    public constructor(
        configuration: Configuration,
        requestFactory?: ExpenseApiRequestFactory,
        responseProcessor?: ExpenseApiResponseProcessor
    ) {
        this.configuration = configuration;
        this.requestFactory = requestFactory || new ExpenseApiRequestFactory(configuration);
        this.responseProcessor = responseProcessor || new ExpenseApiResponseProcessor();
    }

    /**
     * @param expenseDto
     */
    public apiExpenseAddOrUpdatePostWithHttpInfo(expenseDto?: ExpenseDto, _options?: Configuration): Observable<HttpInfo<ExpenseDto>> {
        const requestContextPromise = this.requestFactory.apiExpenseAddOrUpdatePost(expenseDto, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiExpenseAddOrUpdatePostWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param expenseDto
     */
    public apiExpenseAddOrUpdatePost(expenseDto?: ExpenseDto, _options?: Configuration): Observable<ExpenseDto> {
        return this.apiExpenseAddOrUpdatePostWithHttpInfo(expenseDto, _options).pipe(map((apiResponse: HttpInfo<ExpenseDto>) => apiResponse.data));
    }

    /**
     * @param expenseId
     */
    public apiExpenseDeleteWithHttpInfo(expenseId?: number, _options?: Configuration): Observable<HttpInfo<boolean>> {
        const requestContextPromise = this.requestFactory.apiExpenseDelete(expenseId, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiExpenseDeleteWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param expenseId
     */
    public apiExpenseDelete(expenseId?: number, _options?: Configuration): Observable<boolean> {
        return this.apiExpenseDeleteWithHttpInfo(expenseId, _options).pipe(map((apiResponse: HttpInfo<boolean>) => apiResponse.data));
    }

    /**
     * @param id
     */
    public apiExpenseGetWithHttpInfo(id?: number, _options?: Configuration): Observable<HttpInfo<ExpenseDto>> {
        const requestContextPromise = this.requestFactory.apiExpenseGet(id, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiExpenseGetWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param id
     */
    public apiExpenseGet(id?: number, _options?: Configuration): Observable<ExpenseDto> {
        return this.apiExpenseGetWithHttpInfo(id, _options).pipe(map((apiResponse: HttpInfo<ExpenseDto>) => apiResponse.data));
    }

    /**
     */
    public apiExpenseGetAllGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<Array<ExpenseDto>>> {
        const requestContextPromise = this.requestFactory.apiExpenseGetAllGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiExpenseGetAllGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiExpenseGetAllGet(_options?: Configuration): Observable<Array<ExpenseDto>> {
        return this.apiExpenseGetAllGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<Array<ExpenseDto>>) => apiResponse.data));
    }

    /**
     * @param minAmount
     * @param maxAmount
     */
    public apiExpenseGetByAmountRangeGetWithHttpInfo(minAmount?: number, maxAmount?: number, _options?: Configuration): Observable<HttpInfo<Array<ExpenseDto>>> {
        const requestContextPromise = this.requestFactory.apiExpenseGetByAmountRangeGet(minAmount, maxAmount, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiExpenseGetByAmountRangeGetWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param minAmount
     * @param maxAmount
     */
    public apiExpenseGetByAmountRangeGet(minAmount?: number, maxAmount?: number, _options?: Configuration): Observable<Array<ExpenseDto>> {
        return this.apiExpenseGetByAmountRangeGetWithHttpInfo(minAmount, maxAmount, _options).pipe(map((apiResponse: HttpInfo<Array<ExpenseDto>>) => apiResponse.data));
    }

    /**
     * @param categoryId
     */
    public apiExpenseGetByCategoryGetWithHttpInfo(categoryId?: number, _options?: Configuration): Observable<HttpInfo<Array<ExpenseDto>>> {
        const requestContextPromise = this.requestFactory.apiExpenseGetByCategoryGet(categoryId, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiExpenseGetByCategoryGetWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param categoryId
     */
    public apiExpenseGetByCategoryGet(categoryId?: number, _options?: Configuration): Observable<Array<ExpenseDto>> {
        return this.apiExpenseGetByCategoryGetWithHttpInfo(categoryId, _options).pipe(map((apiResponse: HttpInfo<Array<ExpenseDto>>) => apiResponse.data));
    }

    /**
     * @param startDate
     * @param endDate
     */
    public apiExpenseGetByDateRangeGetWithHttpInfo(startDate?: Date, endDate?: Date, _options?: Configuration): Observable<HttpInfo<Array<ExpenseDto>>> {
        const requestContextPromise = this.requestFactory.apiExpenseGetByDateRangeGet(startDate, endDate, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiExpenseGetByDateRangeGetWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param startDate
     * @param endDate
     */
    public apiExpenseGetByDateRangeGet(startDate?: Date, endDate?: Date, _options?: Configuration): Observable<Array<ExpenseDto>> {
        return this.apiExpenseGetByDateRangeGetWithHttpInfo(startDate, endDate, _options).pipe(map((apiResponse: HttpInfo<Array<ExpenseDto>>) => apiResponse.data));
    }

}

export class ObservableIncomeApi {
    private requestFactory: IncomeApiRequestFactory;
    private responseProcessor: IncomeApiResponseProcessor;
    private configuration: Configuration;

    public constructor(
        configuration: Configuration,
        requestFactory?: IncomeApiRequestFactory,
        responseProcessor?: IncomeApiResponseProcessor
    ) {
        this.configuration = configuration;
        this.requestFactory = requestFactory || new IncomeApiRequestFactory(configuration);
        this.responseProcessor = responseProcessor || new IncomeApiResponseProcessor();
    }

    /**
     * @param incomeDto
     */
    public apiIncomeAddOrUpdatePostWithHttpInfo(incomeDto?: IncomeDto, _options?: Configuration): Observable<HttpInfo<IncomeDto>> {
        const requestContextPromise = this.requestFactory.apiIncomeAddOrUpdatePost(incomeDto, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiIncomeAddOrUpdatePostWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param incomeDto
     */
    public apiIncomeAddOrUpdatePost(incomeDto?: IncomeDto, _options?: Configuration): Observable<IncomeDto> {
        return this.apiIncomeAddOrUpdatePostWithHttpInfo(incomeDto, _options).pipe(map((apiResponse: HttpInfo<IncomeDto>) => apiResponse.data));
    }

    /**
     * @param incomeId
     */
    public apiIncomeDeleteWithHttpInfo(incomeId?: number, _options?: Configuration): Observable<HttpInfo<boolean>> {
        const requestContextPromise = this.requestFactory.apiIncomeDelete(incomeId, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiIncomeDeleteWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param incomeId
     */
    public apiIncomeDelete(incomeId?: number, _options?: Configuration): Observable<boolean> {
        return this.apiIncomeDeleteWithHttpInfo(incomeId, _options).pipe(map((apiResponse: HttpInfo<boolean>) => apiResponse.data));
    }

    /**
     */
    public apiIncomeDeleteAllDeleteWithHttpInfo(_options?: Configuration): Observable<HttpInfo<boolean>> {
        const requestContextPromise = this.requestFactory.apiIncomeDeleteAllDelete(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiIncomeDeleteAllDeleteWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiIncomeDeleteAllDelete(_options?: Configuration): Observable<boolean> {
        return this.apiIncomeDeleteAllDeleteWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<boolean>) => apiResponse.data));
    }

    /**
     * @param id
     */
    public apiIncomeGetWithHttpInfo(id?: number, _options?: Configuration): Observable<HttpInfo<IncomeDto>> {
        const requestContextPromise = this.requestFactory.apiIncomeGet(id, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiIncomeGetWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param id
     */
    public apiIncomeGet(id?: number, _options?: Configuration): Observable<IncomeDto> {
        return this.apiIncomeGetWithHttpInfo(id, _options).pipe(map((apiResponse: HttpInfo<IncomeDto>) => apiResponse.data));
    }

    /**
     */
    public apiIncomeGetAllGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<Array<IncomeDto>>> {
        const requestContextPromise = this.requestFactory.apiIncomeGetAllGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiIncomeGetAllGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiIncomeGetAllGet(_options?: Configuration): Observable<Array<IncomeDto>> {
        return this.apiIncomeGetAllGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<Array<IncomeDto>>) => apiResponse.data));
    }

}

export class ObservableUserApi {
    private requestFactory: UserApiRequestFactory;
    private responseProcessor: UserApiResponseProcessor;
    private configuration: Configuration;

    public constructor(
        configuration: Configuration,
        requestFactory?: UserApiRequestFactory,
        responseProcessor?: UserApiResponseProcessor
    ) {
        this.configuration = configuration;
        this.requestFactory = requestFactory || new UserApiRequestFactory(configuration);
        this.responseProcessor = responseProcessor || new UserApiResponseProcessor();
    }

    /**
     */
    public apiUserBalanceGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<number>> {
        const requestContextPromise = this.requestFactory.apiUserBalanceGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserBalanceGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiUserBalanceGet(_options?: Configuration): Observable<number> {
        return this.apiUserBalanceGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<number>) => apiResponse.data));
    }

    /**
     */
    public apiUserDeleteAllDeleteWithHttpInfo(_options?: Configuration): Observable<HttpInfo<boolean>> {
        const requestContextPromise = this.requestFactory.apiUserDeleteAllDelete(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserDeleteAllDeleteWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiUserDeleteAllDelete(_options?: Configuration): Observable<boolean> {
        return this.apiUserDeleteAllDeleteWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<boolean>) => apiResponse.data));
    }

    /**
     */
    public apiUserExportDataGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<UserTransactionsDto>> {
        const requestContextPromise = this.requestFactory.apiUserExportDataGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserExportDataGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiUserExportDataGet(_options?: Configuration): Observable<UserTransactionsDto> {
        return this.apiUserExportDataGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<UserTransactionsDto>) => apiResponse.data));
    }

    /**
     * @param categories
     * @param dateFrom
     * @param dateTo
     */
    public apiUserFilteredTransactionsGetWithHttpInfo(categories?: Array<number>, dateFrom?: Date, dateTo?: Date, _options?: Configuration): Observable<HttpInfo<UserTransactionsDto>> {
        const requestContextPromise = this.requestFactory.apiUserFilteredTransactionsGet(categories, dateFrom, dateTo, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserFilteredTransactionsGetWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param categories
     * @param dateFrom
     * @param dateTo
     */
    public apiUserFilteredTransactionsGet(categories?: Array<number>, dateFrom?: Date, dateTo?: Date, _options?: Configuration): Observable<UserTransactionsDto> {
        return this.apiUserFilteredTransactionsGetWithHttpInfo(categories, dateFrom, dateTo, _options).pipe(map((apiResponse: HttpInfo<UserTransactionsDto>) => apiResponse.data));
    }

    /**
     */
    public apiUserGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<UserDto>> {
        const requestContextPromise = this.requestFactory.apiUserGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiUserGet(_options?: Configuration): Observable<UserDto> {
        return this.apiUserGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<UserDto>) => apiResponse.data));
    }

    /**
     * @param userTransactionsDto
     */
    public apiUserImportDataPostWithHttpInfo(userTransactionsDto?: UserTransactionsDto, _options?: Configuration): Observable<HttpInfo<boolean>> {
        const requestContextPromise = this.requestFactory.apiUserImportDataPost(userTransactionsDto, _options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserImportDataPostWithHttpInfo(rsp)));
        }));
    }

    /**
     * @param userTransactionsDto
     */
    public apiUserImportDataPost(userTransactionsDto?: UserTransactionsDto, _options?: Configuration): Observable<boolean> {
        return this.apiUserImportDataPostWithHttpInfo(userTransactionsDto, _options).pipe(map((apiResponse: HttpInfo<boolean>) => apiResponse.data));
    }

    /**
     */
    public apiUserStatisticsGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<UserStatisticsDto>> {
        const requestContextPromise = this.requestFactory.apiUserStatisticsGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserStatisticsGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiUserStatisticsGet(_options?: Configuration): Observable<UserStatisticsDto> {
        return this.apiUserStatisticsGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<UserStatisticsDto>) => apiResponse.data));
    }

    /**
     */
    public apiUserStatsGraphGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<MemoryStream>> {
        const requestContextPromise = this.requestFactory.apiUserStatsGraphGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserStatsGraphGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiUserStatsGraphGet(_options?: Configuration): Observable<MemoryStream> {
        return this.apiUserStatsGraphGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<MemoryStream>) => apiResponse.data));
    }

    /**
     */
    public apiUserTotalExpenseGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<number>> {
        const requestContextPromise = this.requestFactory.apiUserTotalExpenseGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserTotalExpenseGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiUserTotalExpenseGet(_options?: Configuration): Observable<number> {
        return this.apiUserTotalExpenseGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<number>) => apiResponse.data));
    }

    /**
     */
    public apiUserTotalIncomeGetWithHttpInfo(_options?: Configuration): Observable<HttpInfo<number>> {
        const requestContextPromise = this.requestFactory.apiUserTotalIncomeGet(_options);

        // build promise chain
        let middlewarePreObservable = from<RequestContext>(requestContextPromise);
        for (let middleware of this.configuration.middleware) {
            middlewarePreObservable = middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => middleware.pre(ctx)));
        }

        return middlewarePreObservable.pipe(mergeMap((ctx: RequestContext) => this.configuration.httpApi.send(ctx))).pipe(mergeMap((response: ResponseContext) => {
            let middlewarePostObservable = of(response);
            for (let middleware of this.configuration.middleware) {
                middlewarePostObservable = middlewarePostObservable.pipe(mergeMap((rsp: ResponseContext) => middleware.post(rsp)));
            }
            return middlewarePostObservable.pipe(map((rsp: ResponseContext) => this.responseProcessor.apiUserTotalIncomeGetWithHttpInfo(rsp)));
        }));
    }

    /**
     */
    public apiUserTotalIncomeGet(_options?: Configuration): Observable<number> {
        return this.apiUserTotalIncomeGetWithHttpInfo(_options).pipe(map((apiResponse: HttpInfo<number>) => apiResponse.data));
    }

}
