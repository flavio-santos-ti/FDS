
CREATE TABLE audit_logs (
    id UUID PRIMARY KEY,
    event_timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    event_action VARCHAR(255) NOT NULL,
    context_name VARCHAR(255) NOT NULL,
    http_status_code INTEGER,
    event_message TEXT,
    request_data JSONB, 
    response_data JSONB,
    user_email VARCHAR(255)
);
