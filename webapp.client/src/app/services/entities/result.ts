interface IResult<T>
{
    resultCode: number,
    errorMessage: string | null,
    content: T | null
}

interface IResultSimple
{
    resultCode: number,
    errorMessage: string | null
}

export class ResultSimple implements IResultSimple {
    resultCode: number;
    errorMessage: string | null;

    constructor(_resultCode: number, _errorMessage: string | null = null) {
        this.resultCode = _resultCode;
        this.errorMessage = _errorMessage;
    }
}

export class Result<T> implements IResult<T> {
    resultCode: number;
    errorMessage: string | null;
    content: T | null;

    constructor(_resultCode: number, _errorMessage: string | null = null, _content: T | null = null) {
        this.resultCode = _resultCode;
        this.errorMessage = _errorMessage;
        this.content = _content;
    }

    static Ok<T>(content: T): Result<T> {
        return new Result<T>(200, null, content);
    }

    static Error<T>(errorMessage: string): Result<T> {
        return new Result<T>(500, errorMessage, null);
    }
}