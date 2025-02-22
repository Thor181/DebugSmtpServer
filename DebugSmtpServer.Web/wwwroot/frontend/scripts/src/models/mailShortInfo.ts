export default interface IMailShortInfo {
    from: string,
    to: string[],
    subject: string,
    body: string,
    date: Date
}