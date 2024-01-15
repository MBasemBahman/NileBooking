namespace Services;

public class CyberSourcePaymentService
{
    public string GenerateCyberSourceForm(string transactionAmount, string currency, string transactionType, string accessKey, string profileId, string transactionSignature, string transactionReferenceNumber, string redirectUrl)
    {
        string secureAcceptanceURL = "https://testsecureacceptance.cybersource.com/pay";

        string form = $@"
            <form id='payment-form' action='{secureAcceptanceURL}' method='post'>
                <input type='hidden' name='access_key' value='{accessKey}' />
                <input type='hidden' name='profile_id' value='{profileId}' />
                <input type='hidden' name='transaction_uuid' value='{transactionReferenceNumber}' />
                <input type='hidden' name='signed_field_names' value='access_key,profile_id,transaction_uuid,signed_field_names,unsigned_field_names,signed_date_time,locale,transaction_type,reference_number,amount,currency,override_custom_receipt_page' />
                <input type='hidden' name='unsigned_field_names' value='' />
                <input type='hidden' name='locale' value='en' />
                <input type='hidden' name='transaction_type' value='{transactionType}' />
                <input type='hidden' name='reference_number' value='{transactionReferenceNumber}' />
                <input type='hidden' name='amount' value='{transactionAmount}' />
                <input type='hidden' name='currency' value='{currency}' />
                <input type='hidden' name='signed_date_time' value='{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}' />
                <input type='hidden' name='signature' value='{transactionSignature}' />
                <input type='hidden' name='override_custom_receipt_page' value='{redirectUrl}' />
                <input type='submit' value='Submit Payment Information' />
            </form>";

        return form;
    }
}