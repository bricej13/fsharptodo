module todo.web.Controllers

open Giraffe
open Microsoft.AspNetCore.Http
open todo.service

let getAllHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        json TodoService.getAll next ctx
        
let getActiveHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        json TodoService.getActive next ctx

let getHandler id =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        match TodoService.get id with
        | Some t -> json t next ctx
        | None -> RequestErrors.NOT_FOUND $"No todo found with id %i{id}" next ctx
