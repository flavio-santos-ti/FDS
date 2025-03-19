
CREATE TABLE audit_logs (
    id UUID PRIMARY KEY,
    event_timestamp_local TIMESTAMP WITHOUT TIME ZONE,
    event_timestamp_utc TIMESTAMP WITH TIME ZONE,
    event_action VARCHAR(255) NOT NULL,
    context_name VARCHAR(255) NOT NULL,
    trace_identifier VARCHAR(50),
    http_method VARCHAR(10) NOT NULL, 
    request_path VARCHAR(500),
    http_status_code INTEGER,
    event_message TEXT,
    request_data JSONB, 
    response_data JSONB,
    user_id UUID
);

CREATE INDEX idx_audit_logs_user_id ON audit_logs (user_id);