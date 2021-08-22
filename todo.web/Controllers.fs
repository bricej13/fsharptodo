module todo.web.Controllers

open Giraffe
open Microsoft.AspNetCore.Http
open todo.service

let getAllHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        json TodoService.getAll next ctx

