Imports SAP.Middleware.Connector

Public Class ECCDestinationConfig
    Implements IDestinationConfiguration
    Public Event ConfigurationChanged(ByVal destinationName As String, ByVal args As RfcConfigurationEventArgs) Implements IDestinationConfiguration.ConfigurationChanged
    Public Function GetParameters(ByVal destinationName As String) As RfcConfigParameters Implements IDestinationConfiguration.GetParameters
        Dim parms As New RfcConfigParameters
        Select Case destinationName
            Case "EZC"
                parms.Add(RfcConfigParameters.AppServerHost, AppServerHost)
                parms.Add(RfcConfigParameters.SystemNumber, SystemNumber)
                parms.Add(RfcConfigParameters.SystemID, SystemID)
                parms.Add(RfcConfigParameters.User, UserSAP)
                parms.Add(RfcConfigParameters.Password, PasswordSAP.Trim)
                parms.Add(RfcConfigParameters.Client, Client)
                parms.Add(RfcConfigParameters.Language, Language) 'Language
                parms.Add(RfcConfigParameters.PoolSize, PoolSize) 'PoolSize
                parms.Add(RfcConfigParameters.PeakConnectionsLimit, MaxPoolSize) 'MaxPoolSize
                parms.Add(RfcConfigParameters.ConnectionIdleTimeout, IdleTimeout) 'IdleTimeou

            Case Else
        End Select
        Return parms
    End Function
    Public Function ChangeEventsSupported() As Boolean Implements IDestinationConfiguration.ChangeEventsSupported
        Return False
    End Function
End Class
