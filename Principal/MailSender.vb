Imports System.Text
Imports System.Net.Mail

Public Class MailSender

    Property MailFrom As String
    Property MailTo As String
    Property MailSubject As String
    Property MailMessage As String
    Property Attachs As New List(Of String)
    Property SmtpHost As String
    Property SmtpPort As String
    Property Username As String
    Property Password As String
    Property UseSSL As Boolean

    Public Sub SendEmailMessage()

        'This procedure overrides the first procedure and accepts a single
        'string for the recipient and file attachement 
        Try


            Dim MailMsg As New MailMessage(New MailAddress(MailFrom.Trim()), New MailAddress(MailTo))
            MailMsg.BodyEncoding = Encoding.Default
            MailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            MailMsg.Subject = MailSubject.Trim()
            MailMsg.Body = MailMessage.Trim() & vbCrLf
            MailMsg.Priority = MailPriority.High
            MailMsg.IsBodyHtml = True

            For Each s As String In Attachs
                Dim MsgAttach As New Attachment(s)
                MailMsg.Attachments.Add(MsgAttach)
            Next

            'Smtpclient to send the mail message
            Dim SmtpMail As New SmtpClient
            SmtpMail.Host = SmtpHost
            SmtpMail.Port = SmtpPort
            SmtpMail.EnableSsl = UseSSL
            SmtpMail.Credentials = New System.Net.NetworkCredential(Username, Password)
            SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network
            SmtpMail.Send(MailMsg)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
