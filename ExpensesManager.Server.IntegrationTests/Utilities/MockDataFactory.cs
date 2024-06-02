﻿using ExpensesManager.Server.DTOs.Auth;
using ExpensesManager.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace ExpensesManager.Server.IntegrationTests;

public static class MockDataFactory
{
    public static string password = "seededUser123!";

    public static RegistrationDto CreateRegistrationDto(string email, string password)
    {
        return new RegistrationDto
        {
            Email = email,
            Password = password,
            ConfirmPassword = password
        };
    }

    public static LoginDto CreateLoginDto(string email, string password)
    {
        return new LoginDto
        {
            Email = email,
            Password = password
        };
    }

    public static LoginDto CreateLoginDto(IdentityUser user)
    {
        return new LoginDto
        {
            Email = user.Email ?? string.Empty,
            Password = password
        };
    }

    public static List<IdentityUser> CreateUsers()
    {
        var users = new List<IdentityUser>
        {
            new() { UserName = "firstUser", Email = "firstUser@example.com" },
            new() { UserName = "secondUser", Email = "secondUser@example.com" }
        };

        return users;
    }

    public static List<Income> CreateIncomes(string userId, int categoryId)
    {
        var incomes = new List<Income>
        {
            new()
            {
                Amount = 1000, CategoryId = categoryId, Date = DateTime.Now, UserId = userId,
                Description = "Salary"
            },
            new()
            {
                Amount = 2000, CategoryId = categoryId, Date = DateTime.Now, UserId = userId,
                Description = "Salary"
            }
        };

        return incomes;
    }

    public static List<Expense> CreateExpenses(string userId, int categoryId)
    {
        var expenses = new List<Expense>
        {
            new()
            {
                Amount = 100, CategoryId = categoryId, Date = DateTime.Now, UserId = userId,
                Description = "Bread"
            },
            new()
            {
                Amount = 200, CategoryId = categoryId, Date = DateTime.Now, UserId = userId,
                Description = "Vegetables"
            }
        };

        return expenses;
    }

    public static List<Category> CreateCategories(string userId)
    {
        var categories = new List<Category>
        {
            new() { Name = "Food", UserId = userId },
            new() { Name = "Transport", UserId = userId },
            new() { Name = "Salary", UserId = userId }
        };

        return categories;
    }
}
