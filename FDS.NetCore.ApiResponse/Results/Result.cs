﻿using FDS.NetCore.ApiResponse.Models;
using FDS.NetCore.ApiResponse.Types;

namespace FDS.NetCore.ApiResponse.Results;

/// <summary>
/// Provides a factory for creating standardized API response objects.
/// </summary>
public static class Result
{
    /// <summary>
    /// Creates a standardized response object for API responses.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the response.</typeparam>
    /// <param name="actionType">The action type indicating the context of the response.</param>
    /// <param name="message">A descriptive message for the response. Defaults to "Success".</param>
    /// <param name="data">The optional data payload.</param>
    /// <returns>A standardized response object containing the result information.</returns>
    public static Response<T> Create<T>(ActionType actionType, string message = "Success", T? data = default)
    { 
        bool success = actionType == ActionType.CREATE ||
                       actionType == ActionType.CREATE_UPLOAD ||
                       actionType == ActionType.CREATE_LOGIN ||
                       actionType == ActionType.DELETE ||
                       actionType == ActionType.UPDATE ||
                       actionType == ActionType.LOGIN_SUCCESS ||
                       actionType == ActionType.READ;

        int statusCode = actionType == ActionType.CREATE ||
                         actionType == ActionType.CREATE_UPLOAD ||
                         actionType == ActionType.CREATE_LOGIN ? 201 :
                         actionType == ActionType.DELETE ||
                         actionType == ActionType.UPDATE ||
                         actionType == ActionType.LOGIN_SUCCESS ||
                         actionType == ActionType.READ ? 200 :
                         actionType == ActionType.NOT_FOUND ? 404 :
                         actionType == ActionType.VALIDATION_ERROR ? 400 :
                         actionType == ActionType.ERROR ? 500 : 200;

        return new Response<T>(actionType, success, message, statusCode, data);
    }
}
