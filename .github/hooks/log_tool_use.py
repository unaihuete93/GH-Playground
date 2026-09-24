import json
import sys
from pathlib import Path


event = json.load(sys.stdin)
log_entry = f"{event['timestamp']} {event['tool_name']}\n"
Path(".github/hooks/tool-use.log").open("a", encoding="utf-8").write(log_entry)
