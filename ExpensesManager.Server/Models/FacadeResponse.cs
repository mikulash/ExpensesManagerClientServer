﻿namespace ExpensesManager.Server.Models;

public class FacadeResponse<T> where T : notnull
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess => StatusCode is >= 200 and < 300;
    public T? Value { get; set; }

    public FacadeResponse<T> SetError(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
        return this;
    }

    public FacadeResponse<T> SetOk(T value)
    {
        StatusCode = 200;
        Value = value;
        return this;
    }

    public FacadeResponse<T> SetOk(int statusCode, T value)
    {
        if (statusCode is < 200 or >= 300)
            throw new ArgumentException("Status code must be between 200 and 299", nameof(statusCode));
        StatusCode = statusCode;
        Value = value;
        return this;
    }

    public FacadeResponse<T> SetBadRequest(string message)
    {
        StatusCode = 400;
        Message = message;
        return this;
    }

    public FacadeResponse<T> SetServerError(string message)
    {
        StatusCode = 500;
        Message = message;
        return this;
    }

    public FacadeResponse<T> SetNotFound(string message)
    {
        StatusCode = 404;
        Message = message;
        return this;
    }
}