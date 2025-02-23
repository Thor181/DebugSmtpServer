export default interface IMailShortInfo {
    id: number,
    from: string,
    to: string[],
    subject: string,
    body: string,
    date: number
}